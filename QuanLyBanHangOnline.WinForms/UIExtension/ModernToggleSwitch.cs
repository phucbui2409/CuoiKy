using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyBanHangOnline.WinForms.UIExtension
{
    /// <summary>
    /// Control Nâng Cao 2: Toggle Switch (Nút gạt công tắc On/Off hiện đại)
    /// Thay thế CheckBox thông thường, kiểu dáng iOS / Android Material Design
    /// </summary>
    public class ModernToggleSwitch : CheckBox
    {
        private Color _onBackColor = UIThemeManager.PrimaryColor;
        private Color _onToggleColor = Color.White;
        private Color _offBackColor = Color.FromArgb(203, 213, 225); // Slate Gray
        private Color _offToggleColor = Color.White;
        private bool _solidStyle = true;

        public ModernToggleSwitch()
        {
            this.MinimumSize = new Size(45, 22);
            this.Size = new Size(50, 25);
            this.Cursor = Cursors.Hand;
        }

        [Category("Modern UI")]
        public Color OnBackColor
        {
            get => _onBackColor;
            set { _onBackColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color OnToggleColor
        {
            get => _onToggleColor;
            set { _onToggleColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color OffBackColor
        {
            get => _offBackColor;
            set { _offBackColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color OffToggleColor
        {
            get => _offToggleColor;
            set { _offToggleColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public bool SolidStyle
        {
            get => _solidStyle;
            set { _solidStyle = value; this.Invalidate(); }
        }

        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(this.Parent?.BackColor ?? Color.White);

            int toggleSize = this.Height - 5;

            using (GraphicsPath path = GetFigurePath())
            {
                if (this.Checked) // BẬT (ON)
                {
                    // Vẽ nền trạng thái bật
                    if (_solidStyle)
                    {
                        using (Brush brush = new SolidBrush(_onBackColor))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                    else
                    {
                        using (Pen pen = new Pen(_onBackColor, 2))
                        {
                            g.DrawPath(pen, path);
                        }
                    }

                    // Vẽ nút tròn gạt sang phải
                    using (Brush brushToggle = new SolidBrush(_onToggleColor))
                    {
                        g.FillEllipse(brushToggle, new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                    }
                }
                else // TẮT (OFF)
                {
                    // Vẽ nền trạng thái tắt
                    if (_solidStyle)
                    {
                        using (Brush brush = new SolidBrush(_offBackColor))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                    else
                    {
                        using (Pen pen = new Pen(_offBackColor, 2))
                        {
                            g.DrawPath(pen, path);
                        }
                    }

                    // Vẽ nút tròn gạt sang trái
                    using (Brush brushToggle = new SolidBrush(_offToggleColor))
                    {
                        g.FillEllipse(brushToggle, new Rectangle(3, 2, toggleSize, toggleSize));
                    }
                }
            }
        }
    }
}
