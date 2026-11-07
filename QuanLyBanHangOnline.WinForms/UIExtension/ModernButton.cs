using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyBanHangOnline.WinForms.UIExtension
{
    /// <summary>
    /// Control Nâng Cao 1: Modern Button
    /// Hỗ trợ Bo góc (BorderRadius), Đường viền (Border), Màu sắc Hover/Press mượt mà
    /// </summary>
    public class ModernButton : Button
    {
        private int _borderSize = 0;
        private int _borderRadius = 8;
        private Color _borderColor = UIThemeManager.PrimaryLight;
        private Color _backgroundColor = UIThemeManager.PrimaryColor;
        private Color _textColor = Color.White;
        private Color _hoverColor;
        private bool _isHovered = false;
        private bool _isPressed = false;

        public ModernButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = _backgroundColor;
            this.ForeColor = _textColor;
            this.Font = UIThemeManager.BodyBoldFont;
            this.Cursor = Cursors.Hand;
            this.Resize += (s, e) => { if (_borderRadius > this.Height) _borderRadius = this.Height; };
            UpdateHoverColor();
        }

        public override Color BackColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                base.BackColor = value;
                UpdateHoverColor();
                this.Invalidate();
            }
        }

        public override Color ForeColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                base.ForeColor = value;
                this.Invalidate();
            }
        }

        [Category("Modern UI")]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color BackgroundColor
        {
            get => this.BackColor;
            set => this.BackColor = value;
        }

        [Category("Modern UI")]
        public Color TextColor
        {
            get => this.ForeColor;
            set => this.ForeColor = value;
        }

        [Category("Modern UI")]
        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; this.Invalidate(); }
        }

        private void UpdateHoverColor()
        {
            // Tự động làm sáng 15% khi hover nếu chưa chỉ định
            int r = Math.Min(255, (int)(_backgroundColor.R * 1.15) + 15);
            int g = Math.Min(255, (int)(_backgroundColor.G * 1.15) + 15);
            int b = Math.Min(255, (int)(_backgroundColor.B * 1.15) + 15);
            _hoverColor = Color.FromArgb(r, g, b);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            _isPressed = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _isPressed = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _isPressed = false;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);
            int smoothSize = 2;
            if (_borderSize > 0) smoothSize = _borderSize;

            Color currentBg = _backgroundColor;
            if (!this.Enabled)
            {
                currentBg = (UIThemeManager.CurrentTheme == ThemeMode.Dark) 
                    ? Color.FromArgb(51, 65, 85) 
                    : Color.FromArgb(203, 213, 225); // Disabled Slate
            }
            else if (_isPressed)
            {
                currentBg = ControlPaint.Dark(_backgroundColor, 0.1f);
            }
            else if (_isHovered)
            {
                currentBg = _hoverColor;
            }

            // Lấy màu nền xung quanh để khử răng cưa viền bo góc hoàn hảo
            Color parentBg = this.Parent?.BackColor ?? (UIThemeManager.CurrentTheme == ThemeMode.Dark ? UIThemeManager.BackgroundColor : Color.White);
            if (parentBg == Color.Transparent && this.Parent != null)
            {
                parentBg = this.Parent.Parent?.BackColor ?? (UIThemeManager.CurrentTheme == ThemeMode.Dark ? UIThemeManager.BackgroundColor : Color.White);
            }

            if (_borderRadius > 2)
            {
                using (GraphicsPath pathSurface = UIThemeManager.GetRoundedPath(rectSurface, _borderRadius))
                using (GraphicsPath pathBorder = UIThemeManager.GetRoundedPath(rectBorder, _borderRadius - _borderSize))
                using (Pen penSurface = new Pen(parentBg, smoothSize))
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                using (Brush brushBg = new SolidBrush(currentBg))
                {
                    // Thiết lập vùng hiển thị của nút
                    this.Region = new Region(pathSurface);

                    // Tô màu nền
                    g.FillPath(brushBg, pathSurface);

                    // Vẽ viền ngoài làm mềm rìa răng cưa
                    g.DrawPath(penSurface, pathSurface);

                    // Vẽ viền (Border) nếu có
                    if (_borderSize >= 1)
                    {
                        g.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                // Nút phẳng không bo góc
                this.Region = new Region(rectSurface);
                using (Brush brushBg = new SolidBrush(currentBg))
                {
                    g.FillRectangle(brushBg, rectSurface);
                }

                if (_borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(_borderColor, _borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        g.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

            // Vẽ Icon và Text
            Color textDrawColor = this.Enabled 
                ? _textColor 
                : (UIThemeManager.CurrentTheme == ThemeMode.Dark ? Color.FromArgb(148, 163, 184) : Color.FromArgb(100, 116, 139));

            TextRenderer.DrawText(g, this.Text, this.Font, rectSurface,
                textDrawColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }
    }
}
