using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace QuanLyBanHangOnline.WinForms.Forms
{
    public partial class frmScanBarcode : Form
    {
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private readonly BarcodeReader _barcodeReader;
        private bool _isScanning = false;
        private DateTime _lastScanTime = DateTime.MinValue;

        /// <summary>
        /// Mã Barcode hoặc QR Code đã quét thành công
        /// </summary>
        public string ScannedCode { get; private set; }

        public frmScanBarcode()
        {
            InitializeComponent();

            _barcodeReader = new BarcodeReader
            {
                AutoRotate = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true,
                    TryInverted = true,
                    PossibleFormats = new[]
                    {
                        BarcodeFormat.CODE_128,
                        BarcodeFormat.CODE_39,
                        BarcodeFormat.EAN_13,
                        BarcodeFormat.EAN_8,
                        BarcodeFormat.UPC_A,
                        BarcodeFormat.QR_CODE
                    }
                }
            };

            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += FrmScanBarcode_Load;
            this.FormClosing += FrmScanBarcode_FormClosing;

            btnStartCamera.Click += (s, e) => StartCamera();
            btnStopCamera.Click += (s, e) => StopCamera();

            btnBrowseImage.Click += BtnBrowseImage_Click;
            btnConfirmManual.Click += BtnConfirmManual_Click;
            txtManualCode.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BtnConfirmManual_Click(s, e);
                }
            };

            btnClose.Click += (s, e) =>
            {
                StopCamera();
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        private void FrmScanBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cboCamera.Items.Clear();

                if (_videoDevices.Count > 0)
                {
                    foreach (FilterInfo device in _videoDevices)
                    {
                        cboCamera.Items.Add(device.Name);
                    }
                    cboCamera.SelectedIndex = 0;
                    btnStartCamera.Enabled = true;
                    btnStopCamera.Enabled = false;

                    // Tự động bật camera nếu có sẵn
                    StartCamera();
                }
                else
                {
                    cboCamera.Items.Add("Không tìm thấy Webcam trên máy tính");
                    cboCamera.SelectedIndex = 0;
                    cboCamera.Enabled = false;
                    btnStartCamera.Enabled = false;
                    btnStopCamera.Enabled = false;
                    lblStatus.Text = "ℹ Không tìm thấy Webcam. Bạn có thể chọn file ảnh hoặc gõ mã trực tiếp bên dưới.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi khởi tạo camera: " + ex.Message;
            }
        }

        private void StartCamera()
        {
            try
            {
                if (_videoDevices == null || _videoDevices.Count == 0 || cboCamera.SelectedIndex < 0)
                    return;

                StopCamera();

                _videoSource = new VideoCaptureDevice(_videoDevices[cboCamera.SelectedIndex].MonikerString);
                _videoSource.NewFrame += VideoSource_NewFrame;
                _videoSource.Start();

                _isScanning = true;
                btnStartCamera.Enabled = false;
                btnStopCamera.Enabled = true;
                lblStatus.Text = "🎥 Camera đang hoạt động... Đưa mã vạch vào khung hình.";
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Không thể khởi động camera: " + ex.Message;
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void StopCamera()
        {
            try
            {
                _isScanning = false;
                if (_videoSource != null && _videoSource.IsRunning)
                {
                    _videoSource.SignalToStop();
                    _videoSource.NewFrame -= VideoSource_NewFrame;
                    _videoSource = null;
                }

                btnStartCamera.Enabled = (_videoDevices != null && _videoDevices.Count > 0);
                btnStopCamera.Enabled = false;
            }
            catch
            {
                // Bỏ qua lỗi khi giải phóng thiết bị
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!_isScanning) return;

            try
            {
                using (Bitmap frame = (Bitmap)eventArgs.Frame.Clone())
                {
                    // Cập nhật khung hình camera lên PictureBox
                    Bitmap displayBitmap = (Bitmap)frame.Clone();
                    this.BeginInvoke(new Action(() =>
                    {
                        var oldImage = picCamera.Image;
                        picCamera.Image = displayBitmap;
                        oldImage?.Dispose();
                    }));

                    // Chỉ xử lý giải mã mỗi 200ms để giảm tải CPU
                    if ((DateTime.Now - _lastScanTime).TotalMilliseconds > 200)
                    {
                        _lastScanTime = DateTime.Now;
                        var result = _barcodeReader.Decode(frame);
                        if (result != null && !string.IsNullOrWhiteSpace(result.Text))
                        {
                            _isScanning = false;
                            string decoded = result.Text.Trim();

                            this.BeginInvoke(new Action(() =>
                            {
                                try
                                {
                                    SystemSounds.Beep.Play();
                                }
                                catch { }

                                StopCamera();
                                ScannedCode = decoded;
                                lblStatus.Text = $"✔ Quét thành công: {decoded} ({result.BarcodeFormat})";
                                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }));
                        }
                    }
                }
            }
            catch
            {
                // Tránh throw exception từ background frame thread
            }
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Tệp hình ảnh (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Tất cả tệp (*.*)|*.*";
                ofd.Title = "Chọn file hình ảnh chứa mã Barcode / QR Code";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var img = new Bitmap(ofd.FileName))
                        {
                            picCamera.Image?.Dispose();
                            picCamera.Image = (Bitmap)img.Clone();

                            var result = _barcodeReader.Decode(img);
                            if (result != null && !string.IsNullOrWhiteSpace(result.Text))
                            {
                                ScannedCode = result.Text.Trim();
                                MessageBox.Show($"✔ Đã nhận diện được mã: {ScannedCode} ({result.BarcodeFormat})", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                StopCamera();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy mã vạch hoặc mã QR hợp lệ trong hình ảnh đã chọn. Vui lòng thử ảnh khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đọc file ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnConfirmManual_Click(object sender, EventArgs e)
        {
            string code = txtManualCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Vui lòng nhập mã Barcode hoặc mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManualCode.Focus();
                return;
            }

            ScannedCode = code;
            StopCamera();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmScanBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }
    }
}
