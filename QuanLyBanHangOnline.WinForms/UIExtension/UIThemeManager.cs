using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyBanHangOnline.WinForms.UIExtension
{
    public enum ThemeMode
    {
        Light,
        Dark
    }

    /// <summary>
    /// Quản lý Hệ thống Giao diện, Bảng màu (Color Palette), Dark / Light Mode, Font chữ và Bo góc
    /// Áp dụng nhất quán trên toàn bộ các Form trong ứng dụng
    /// </summary>
    public static class UIThemeManager
    {
        #region 0. Dark / Light Mode State
        public static ThemeMode CurrentTheme { get; private set; } = ThemeMode.Light;
        public static event Action<ThemeMode> ThemeChanged;

        /// <summary>
        /// Chuyển đổi qua lại giữa Chế độ Sáng (Light) và Chế độ Tối (Dark)
        /// </summary>
        public static void ToggleTheme()
        {
            CurrentTheme = (CurrentTheme == ThemeMode.Light) ? ThemeMode.Dark : ThemeMode.Light;
            ThemeChanged?.Invoke(CurrentTheme);

            // Tự động cập nhật lại toàn bộ các form đang mở
            foreach (Form openForm in Application.OpenForms)
            {
                ApplyTheme(openForm);
                openForm.Invalidate(true);
            }
        }

        public static void SetTheme(ThemeMode mode)
        {
            if (CurrentTheme != mode)
            {
                CurrentTheme = mode;
                ThemeChanged?.Invoke(CurrentTheme);

                foreach (Form openForm in Application.OpenForms)
                {
                    ApplyTheme(openForm);
                    openForm.Invalidate(true);
                }
            }
        }
        #endregion

        #region 1. Color Palette (Bảng màu nhận diện động theo Light / Dark Mode)
        // Màu chủ đạo (Primary): Deep Ocean Blue
        public static Color PrimaryColor => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(30, 58, 138)       // Dark Blue #1E3A8A
            : Color.FromArgb(21, 101, 192);     // #1565C0

        public static Color PrimaryLight => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(59, 130, 246) 
            : Color.FromArgb(66, 165, 245);

        public static Color PrimaryDark => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(15, 23, 42) 
            : Color.FromArgb(13, 71, 161);

        // Màu phụ (Secondary / Teal):
        public static Color SecondaryColor => Color.FromArgb(0, 150, 136);      // #009688
        public static Color SecondaryLight => Color.FromArgb(77, 182, 172);

        // Màu hành động & trạng thái:
        public static Color SuccessColor => Color.FromArgb(46, 125, 50);        // #2E7D32
        public static Color WarningColor => Color.FromArgb(245, 124, 0);        // #F57C00
        public static Color DangerColor => Color.FromArgb(211, 47, 47);         // #D32F2F
        public static Color InfoColor => Color.FromArgb(2, 136, 209);           // #0288D1

        // Màu nền & khung (Background & Surface) linh hoạt theo Dark Mode:
        public static Color BackgroundColor => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(15, 23, 42)        // Slate 900
            : Color.FromArgb(248, 250, 252);    // Slate 50 #F8FAFC

        public static Color SurfaceColor => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(30, 41, 59)        // Slate 800
            : Color.FromArgb(255, 255, 255);    // White

        public static Color BorderColor => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(51, 65, 85)        // Slate 700
            : Color.FromArgb(226, 232, 240);    // #E2E8F0

        public static Color BorderFocusColor => Color.FromArgb(33, 150, 243);

        // Màu văn bản (Typography) linh hoạt:
        public static Color TextPrimary => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(248, 250, 252)    // Slate 50
            : Color.FromArgb(30, 41, 59);       // Slate 800

        public static Color TextSecondary => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(148, 163, 184)    // Slate 400
            : Color.FromArgb(100, 116, 139);    // Slate 500

        public static Color TextLight => Color.FromArgb(255, 255, 255);

        // Màu tương tác lưới (Grid Hover & Selection):
        public static Color GridHoverColor => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(51, 65, 85)        // Slate 700
            : Color.FromArgb(235, 245, 255);    // Soft Blue hover

        public static Color GridSelectionColor => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(30, 58, 138)       // Deep Blue highlight
            : Color.FromArgb(187, 222, 251);    // Light Blue selection

        public static Color GridAlternateRow => CurrentTheme == ThemeMode.Dark 
            ? Color.FromArgb(24, 33, 47) 
            : Color.FromArgb(250, 252, 255);
        #endregion

        #region 2. Font Chữ Chuẩn (Typography)
        public const string MainFontFamily = "Segoe UI";
        public static readonly Font TitleFont = new Font(MainFontFamily, 15F, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font(MainFontFamily, 9.5F, FontStyle.Regular);
        public static readonly Font HeaderFont = new Font(MainFontFamily, 10.5F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font(MainFontFamily, 9F, FontStyle.Regular);
        public static readonly Font BodyBoldFont = new Font(MainFontFamily, 9F, FontStyle.Bold);
        public static readonly Font SmallFont = new Font(MainFontFamily, 8.5F, FontStyle.Regular);
        #endregion

        #region 3. Bo Góc (Border Radius)
        public const int DefaultBorderRadius = 8;
        public const int LargeBorderRadius = 12;
        public const int SmallBorderRadius = 5;
        #endregion

        #region 4. Tự Động Chuẩn Hóa Toàn Diện Giao Diện Form (Auto-Styler)
        /// <summary>
        /// Áp dụng giao diện hiện đại & Dark/Light mode lên toàn bộ Form và tất cả các control bên trong
        /// </summary>
        public static void ApplyTheme(Form form)
        {
            if (form == null || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;

            form.Font = BodyFont;
            form.BackColor = BackgroundColor;
            form.ForeColor = TextPrimary;

            // Bật double buffering để chống giật/nhấp nháy
            EnableDoubleBuffering(form);

            // Duyệt đệ quy toàn bộ cây controls
            ApplyThemeToControls(form.Controls);
        }

        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            if (controls == null) return;

            foreach (Control c in controls)
            {
                // Áp dụng font Segoe UI
                if (c.Font != null && c.Font.FontFamily.Name != MainFontFamily)
                {
                    c.Font = new Font(MainFontFamily, c.Font.Size, c.Font.Style);
                }

                // 1. Chuẩn hóa DataGridView
                if (c is ModernDataGridView mdgv)
                {
                    mdgv.ApplyModernStyles();
                }
                else if (c is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                // 2. Chuẩn hóa ModernButton & Button
                else if (c is ModernButton mbtn)
                {
                    mbtn.BorderColor = BorderColor;
                    mbtn.Invalidate();
                }
                else if (c is Button btn)
                {
                    StyleStandardButton(btn);
                }
                // 3. Chuẩn hóa CardView
                else if (c is ModernCardView card)
                {
                    card.ApplyTheme();
                }
                // 4. Chuẩn hóa Panel
                else if (c is Panel pnl)
                {
                    if (pnl.Name.StartsWith("panelTop") || pnl.Name.StartsWith("pnlHeader") || pnl.Name.StartsWith("pnlTop") || pnl.Dock == DockStyle.Top)
                    {
                        pnl.BackColor = (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(30, 41, 59) : PrimaryColor;
                        foreach (Control pnlChild in pnl.Controls)
                        {
                            if (pnlChild is Label lblTitle)
                            {
                                lblTitle.ForeColor = TextLight;
                            }
                        }
                    }
                    else
                    {
                        // Panel nội dung thông thường (panelDashboard, panelMain, panelContainer, v.v.)
                        pnl.BackColor = BackgroundColor;
                        pnl.ForeColor = TextPrimary;
                    }
                }
                // 5. Chuẩn hóa GroupBox
                else if (c is GroupBox grp)
                {
                    grp.Font = HeaderFont;
                    grp.ForeColor = TextPrimary;
                    grp.BackColor = BackgroundColor;
                }
                // 6. Chuẩn hóa StatusStrip
                else if (c is StatusStrip ss)
                {
                    ss.BackColor = CurrentTheme == ThemeMode.Dark ? Color.FromArgb(15, 23, 42) : Color.FromArgb(241, 245, 249);
                    ss.ForeColor = TextPrimary;
                    ss.Font = BodyFont;
                    ss.Renderer = new ToolStripProfessionalRenderer(new ModernMenuColorTable());
                    foreach (ToolStripItem item in ss.Items)
                    {
                        if (item.Name == "lblStatusRole")
                        {
                            item.ForeColor = (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(56, 189, 248) : Color.DarkSlateGray;
                        }
                        else
                        {
                            item.ForeColor = TextPrimary;
                        }
                    }
                }
                // 7. Chuẩn hóa MenuStrip
                else if (c is MenuStrip ms)
                {
                    ms.BackColor = CurrentTheme == ThemeMode.Dark ? Color.FromArgb(30, 41, 59) : Color.FromArgb(241, 245, 249);
                    ms.ForeColor = TextPrimary;
                    ms.Font = new Font(MainFontFamily, 9.5F, FontStyle.Regular);
                    ms.Renderer = new ToolStripProfessionalRenderer(new ModernMenuColorTable());
                    StyleMenuStrip(ms);
                }
                // 8. Chuẩn hóa Label
                else if (c is Label lbl)
                {
                    if (!(lbl.Parent is Panel pParent && (pParent.Name.StartsWith("panelTop") || pParent.Name.StartsWith("pnlHeader") || pParent.Name.StartsWith("pnlTop") || pParent.Dock == DockStyle.Top)))
                    {
                        if (lbl.ForeColor != Color.Red && lbl.ForeColor != DangerColor)
                        {
                            lbl.ForeColor = TextPrimary;
                        }
                    }
                }
                // 9. Chuẩn hóa TextBox & RichTextBox
                else if (c is TextBox txt)
                {
                    txt.BackColor = SurfaceColor;
                    txt.ForeColor = TextPrimary;
                }
                else if (c is RichTextBox rtb)
                {
                    rtb.BackColor = SurfaceColor;
                    rtb.ForeColor = TextPrimary;
                }
                // 10. Chuẩn hóa ComboBox
                else if (c is ComboBox cbo)
                {
                    cbo.BackColor = SurfaceColor;
                    cbo.ForeColor = TextPrimary;
                }
                // 11. Chuẩn hóa NumericUpDown
                else if (c is NumericUpDown num)
                {
                    num.BackColor = SurfaceColor;
                    num.ForeColor = TextPrimary;
                }
                // 12. Chuẩn hóa CheckBox & RadioButton
                else if (c is CheckBox chk && !(c is ModernToggleSwitch))
                {
                    chk.ForeColor = TextPrimary;
                    chk.BackColor = Color.Transparent;
                }
                else if (c is RadioButton rdo)
                {
                    rdo.ForeColor = TextPrimary;
                    rdo.BackColor = Color.Transparent;
                }
                // 13. Chuẩn hóa ListBox, ListView, TreeView
                else if (c is ListBox lb)
                {
                    lb.BackColor = SurfaceColor;
                    lb.ForeColor = TextPrimary;
                }
                else if (c is ListView lv)
                {
                    lv.BackColor = SurfaceColor;
                    lv.ForeColor = TextPrimary;
                }
                else if (c is TreeView tv)
                {
                    tv.BackColor = SurfaceColor;
                    tv.ForeColor = TextPrimary;
                }
                // 14. Chuẩn hóa TabControl
                else if (c is TabControl tc)
                {
                    tc.BackColor = BackgroundColor;
                    tc.ForeColor = TextPrimary;
                    foreach (TabPage tp in tc.TabPages)
                    {
                        tp.BackColor = BackgroundColor;
                        tp.ForeColor = TextPrimary;
                    }
                }

                // Duyệt tiếp controls con
                if (c.HasChildren && !(c is DataGridView))
                {
                    ApplyThemeToControls(c.Controls);
                }
            }
        }

        private static void StyleMenuStrip(MenuStrip ms)
        {
            if (ms == null) return;
            foreach (ToolStripItem item in ms.Items)
            {
                if (item.Name == "mnuThemeToggle") continue;
                item.ForeColor = TextPrimary;
                if (item is ToolStripMenuItem menuItem)
                {
                    StyleMenuItems(menuItem);
                }
            }
        }

        private static void StyleMenuItems(ToolStripMenuItem parent)
        {
            if (parent == null) return;
            parent.DropDown.BackColor = SurfaceColor;
            parent.DropDown.ForeColor = TextPrimary;
            foreach (ToolStripItem subItem in parent.DropDownItems)
            {
                if (subItem.Name == "mnuThemeToggle") continue;
                subItem.BackColor = SurfaceColor;
                subItem.ForeColor = TextPrimary;
                if (subItem is ToolStripMenuItem subMenu)
                {
                    StyleMenuItems(subMenu);
                }
            }
        }

        /// <summary>
        /// Tạo kiểu dáng hiện đại cho DataGridView chuẩn với hiệu ứng Hover/Selection và hàng xen kẽ
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            EnableDoubleBuffering(dgv);

            dgv.BackgroundColor = SurfaceColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = BorderColor;

            // Header Style
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextLight;
            dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Row Style & Alternating Row
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 30;
            dgv.DefaultCellStyle.BackColor = SurfaceColor;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = BodyFont;
            dgv.DefaultCellStyle.SelectionBackColor = GridSelectionColor;
            dgv.DefaultCellStyle.SelectionForeColor = (CurrentTheme == ThemeMode.Dark) ? TextLight : TextPrimary;
            dgv.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlternateRow;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelectionColor;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = (CurrentTheme == ThemeMode.Dark) ? TextLight : TextPrimary;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Hiệu ứng Hover đổi màu hàng theo vị trí chuột
            int lastHoverRow = -1;
            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex != lastHoverRow)
                {
                    if (lastHoverRow >= 0 && lastHoverRow < dgv.Rows.Count && !dgv.Rows[lastHoverRow].Selected)
                    {
                        dgv.Rows[lastHoverRow].DefaultCellStyle.BackColor =
                            (lastHoverRow % 2 == 1) ? GridAlternateRow : SurfaceColor;
                    }

                    if (!dgv.Rows[e.RowIndex].Selected)
                    {
                        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = GridHoverColor;
                    }
                    lastHoverRow = e.RowIndex;
                }
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgv.Rows.Count && !dgv.Rows[e.RowIndex].Selected)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        (e.RowIndex % 2 == 1) ? GridAlternateRow : SurfaceColor;
                }
            };
        }

        /// <summary>
        /// Tạo kiểu dáng cho nút bấm thường
        /// </summary>
        public static void StyleStandardButton(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = BodyBoldFont;

            // Nhận diện theo ngữ cảnh màu nút
            string name = btn.Name.ToLower();
            string text = btn.Text.ToLower();

            if (name.Contains("add") || name.Contains("save") || name.Contains("them") || name.Contains("luu") || text.Contains("thêm") || text.Contains("lưu"))
            {
                btn.BackColor = SuccessColor;
                btn.ForeColor = TextLight;
            }
            else if (name.Contains("edit") || name.Contains("sua") || text.Contains("sửa") || name.Contains("update"))
            {
                btn.BackColor = WarningColor;
                btn.ForeColor = TextLight;
            }
            else if (name.Contains("del") || name.Contains("xoa") || text.Contains("xóa") || name.Contains("huy") || text.Contains("hủy") || name.Contains("exit") || text.Contains("thoát"))
            {
                btn.BackColor = DangerColor;
                btn.ForeColor = TextLight;
            }
            else if (name.Contains("print") || name.Contains("in") || name.Contains("export") || name.Contains("xuat") || text.Contains("in") || text.Contains("xuất") || text.Contains("excel"))
            {
                btn.BackColor = Color.FromArgb(16, 185, 129); // Emerald
                btn.ForeColor = TextLight;
            }
            else if (btn.BackColor == SystemColors.Control || btn.BackColor == Color.Transparent || btn.BackColor.IsEmpty)
            {
                btn.BackColor = PrimaryColor;
                btn.ForeColor = TextLight;
            }
        }

        private static void EnableDoubleBuffering(Control c)
        {
            try
            {
                var prop = typeof(Control).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                prop?.SetValue(c, true, null);
            }
            catch { }
        }

        /// <summary>
        /// Vẽ đường bao tròn (GraphicsPath) cho các control bo góc
        /// </summary>
        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            float d = radius * 2F;

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// Bảng màu chuyên nghiệp cho MenuStrip và ToolStrip popup dropdown
        /// </summary>
        private class ModernMenuColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground => SurfaceColor;
            public override Color ImageMarginGradientBegin => SurfaceColor;
            public override Color ImageMarginGradientMiddle => SurfaceColor;
            public override Color ImageMarginGradientEnd => SurfaceColor;
            public override Color MenuBorder => BorderColor;
            public override Color MenuItemBorder => BorderColor;
            public override Color MenuItemSelected => GridHoverColor;
            public override Color MenuStripGradientBegin => (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(30, 41, 59) : Color.FromArgb(241, 245, 249);
            public override Color MenuStripGradientEnd => (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(30, 41, 59) : Color.FromArgb(241, 245, 249);
            public override Color MenuItemSelectedGradientBegin => GridHoverColor;
            public override Color MenuItemSelectedGradientEnd => GridHoverColor;
            public override Color MenuItemPressedGradientBegin => (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(51, 65, 85) : Color.FromArgb(219, 234, 254);
            public override Color MenuItemPressedGradientEnd => (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(51, 65, 85) : Color.FromArgb(219, 234, 254);
            public override Color SeparatorDark => BorderColor;
            public override Color SeparatorLight => Color.Transparent;
            public override Color StatusStripGradientBegin => (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(15, 23, 42) : Color.FromArgb(241, 245, 249);
            public override Color StatusStripGradientEnd => (CurrentTheme == ThemeMode.Dark) ? Color.FromArgb(15, 23, 42) : Color.FromArgb(241, 245, 249);
        }
        #endregion
    }
}
