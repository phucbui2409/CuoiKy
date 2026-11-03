using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHangOnline.WinForms.UIExtension
{
    /// <summary>
    /// Control Nâng Cao 4: Custom DataGridView với Hiệu Ứng Hover & Selection Đẳng Cấp
    /// Tự động định dạng Header hiện đại, Hàng xen kẽ, Hiệu ứng rê chuột đổi màu mượt mà
    /// </summary>
    public class ModernDataGridView : DataGridView
    {
        private int _hoverRowIndex = -1;
        private Color _hoverRowColor = UIThemeManager.GridHoverColor;
        private Color _selectionRowColor = UIThemeManager.GridSelectionColor;
        private Color _headerColor = UIThemeManager.PrimaryColor;
        private Color _alternateRowColor = UIThemeManager.GridAlternateRow;

        public ModernDataGridView()
        {
            ApplyModernStyles();
        }

        [Category("Modern UI")]
        public Color HoverRowColor
        {
            get => _hoverRowColor;
            set { _hoverRowColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color SelectionRowColor
        {
            get => _selectionRowColor;
            set { _selectionRowColor = value; this.Invalidate(); }
        }

        [Category("Modern UI")]
        public Color HeaderColor
        {
            get => _headerColor;
            set
            {
                _headerColor = value;
                this.ColumnHeadersDefaultCellStyle.BackColor = value;
                this.Invalidate();
            }
        }

        [Category("Modern UI")]
        public Color AlternateRowColor
        {
            get => _alternateRowColor;
            set
            {
                _alternateRowColor = value;
                this.AlternatingRowsDefaultCellStyle.BackColor = value;
                this.Invalidate();
            }
        }

        private void ApplyModernStyles()
        {
            // Bật DoubleBuffering chống giật lag
            this.DoubleBuffered = true;

            this.BackgroundColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridColor = UIThemeManager.BorderColor;

            // Column Header
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersDefaultCellStyle.BackColor = _headerColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.ColumnHeadersDefaultCellStyle.Font = UIThemeManager.HeaderFont;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            this.ColumnHeadersHeight = 38;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Rows & Selection
            this.RowHeadersVisible = false;
            this.RowTemplate.Height = 32;
            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = UIThemeManager.TextPrimary;
            this.DefaultCellStyle.Font = UIThemeManager.BodyFont;
            this.DefaultCellStyle.SelectionBackColor = _selectionRowColor;
            this.DefaultCellStyle.SelectionForeColor = UIThemeManager.TextPrimary;
            this.DefaultCellStyle.Padding = new Padding(6, 2, 6, 2);

            this.AlternatingRowsDefaultCellStyle.BackColor = _alternateRowColor;
            this.AlternatingRowsDefaultCellStyle.ForeColor = UIThemeManager.TextPrimary;
            this.AlternatingRowsDefaultCellStyle.SelectionBackColor = _selectionRowColor;
            this.AlternatingRowsDefaultCellStyle.SelectionForeColor = UIThemeManager.TextPrimary;

            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.AllowUserToResizeRows = false;
        }

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            if (e.RowIndex >= 0 && e.RowIndex < this.Rows.Count && e.RowIndex != _hoverRowIndex)
            {
                int oldHover = _hoverRowIndex;
                _hoverRowIndex = e.RowIndex;

                if (oldHover >= 0 && oldHover < this.Rows.Count && !this.Rows[oldHover].Selected)
                {
                    this.InvalidateRow(oldHover);
                }

                if (!this.Rows[_hoverRowIndex].Selected)
                {
                    this.InvalidateRow(_hoverRowIndex);
                }
            }
        }

        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            if (_hoverRowIndex >= 0 && _hoverRowIndex < this.Rows.Count)
            {
                int oldHover = _hoverRowIndex;
                _hoverRowIndex = -1;
                if (!this.Rows[oldHover].Selected)
                {
                    this.InvalidateRow(oldHover);
                }
            }
        }

        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            base.OnRowPrePaint(e);

            // Tự động tô màu hiệu ứng Hover mượt mà
            if (e.RowIndex == _hoverRowIndex && !this.Rows[e.RowIndex].Selected)
            {
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor = _hoverRowColor;
            }
            else if (!this.Rows[e.RowIndex].Selected)
            {
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    (e.RowIndex % 2 == 1) ? _alternateRowColor : Color.White;
            }
        }
    }
}
