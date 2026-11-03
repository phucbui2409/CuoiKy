using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyBanHangOnline.WinForms.UIExtension
{
    /// <summary>
    /// Control Nâng Cao 3: Card View (Thẻ thông tin / Card Panel hiện đại)
    /// Hỗ trợ Bo góc, Viền đổ bóng nhẹ (Elevation), Thanh tiêu đề Header màu nhận diện
    /// </summary>
    public class ModernCardView : Panel
    {
        private int _borderRadius = 10;
        private int _borderSize = 1;
        private Color _cardColor = Color.White;
        private Color _borderColor = UIThemeManager.BorderColor;
        private Color _headerColor = Color.Transparent;
        private int _headerHeight = 0;
        private string _headerTitle = string.Empty;
        private Color _headerTextColor = Color.White;

        public ModernCardView()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            this.Padding = new Padding(12);
            this.Size = new Size(240, 140);
        }

        [Category("Modern UI")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color CardColor
        {
            get => _cardColor;
            set { _cardColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color HeaderColor
        {
            get => _headerColor;
            set { _headerColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public int HeaderHeight
        {
            get => _headerHeight;
            set { _headerHeight = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public string HeaderTitle
        {
            get => _headerTitle;
            set { _headerTitle = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color HeaderTextColor
        {
            get => _headerTextColor;
            set { _headerTextColor = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            if (_borderRadius > 0)
            {
                using (GraphicsPath path = UIThemeManager.GetRoundedPath(rect, _borderRadius))
                {
                    // Đổ màu nền Card
                    using (Brush brushBg = new SolidBrush(_cardColor))
                    {
                        g.FillPath(brushBg, path);
                    }

                    // Vẽ thanh Header nếu có
                    if (_headerHeight > 0 && _headerColor != Color.Transparent)
                    {
                        Rectangle headerRect = new Rectangle(0, 0, this.Width - 1, _headerHeight);
                        using (GraphicsPath headerPath = GetTopRoundedPath(headerRect, _borderRadius))
                        using (Brush brushHeader = new SolidBrush(_headerColor))
                        {
                            g.FillPath(brushHeader, headerPath);
                        }

                        if (!string.IsNullOrEmpty(_headerTitle))
                        {
                            using (Font font = new Font(UIThemeManager.MainFontFamily, 10F, FontStyle.Bold))
                            {
                                TextRenderer.DrawText(g, _headerTitle, font,
                                    new Rectangle(12, 0, this.Width - 24, _headerHeight),
                                    _headerTextColor,
                                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                            }
                        }
                    }

                    // Vẽ viền Card
                    if (_borderSize > 0)
                    {
                        using (Pen penBorder = new Pen(_borderColor, _borderSize))
                        {
                            g.DrawPath(penBorder, path);
                        }
                    }
                }
            }
            else
            {
                using (Brush brushBg = new SolidBrush(_cardColor))
                {
                    g.FillRectangle(brushBg, rect);
                }

                if (_borderSize > 0)
                {
                    using (Pen penBorder = new Pen(_borderColor, _borderSize))
                    {
                        g.DrawRectangle(penBorder, rect);
                    }
                }
            }
        }

        private GraphicsPath GetTopRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom);
            path.CloseFigure();
            return path;
        }
    }
}
