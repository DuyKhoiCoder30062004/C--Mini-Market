using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace MiniStore.Modules.OrderManager.UI
{
    public static class Style
    {
        public static readonly Color PRIMARY_COLOR = Color.FromArgb(79, 64, 187);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
       int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
       int nWidthEllipse, int nHeightEllipse
   );


        public static void ApplyStyleButtonWithICon(IconButton button, string text, IconChar icon, Color baseColor)
        {

            button.Text = text;
            button.IconChar = icon;
            button.IconColor = Color.White;
            button.IconSize = 22;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.ImageAlign = ContentAlignment.MiddleLeft;


            button.Height = 40;
            button.Width = 140;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);


            Color hoverColor = ControlPaint.Light(baseColor, 0.2f);
            Color activeColor = ControlPaint.Dark(baseColor, 0.2f);

            button.BackColor = baseColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;


            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width, button.Height, 10, 10));




            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = baseColor;
            button.MouseDown += (s, e) => button.BackColor = activeColor;
            button.MouseUp += (s, e) => button.BackColor = hoverColor;
        }

        public static void ApplyStyleInput(TextBox input, string placeholder)
        {

            input.Multiline = true;
            input.Height = 40;
            input.AcceptsReturn = false;
            input.ScrollBars = ScrollBars.None;



            input.BorderStyle = BorderStyle.Fixed3D;

            input.Text = placeholder;
            input.ForeColor = Color.Gray;


            Color defaultBackColor = input.BackColor;


            Color focusBackColor = Color.FromArgb(240, 248, 255);


            input.Enter += (sender, e) =>
            {

                if (input.Text == placeholder && input.ForeColor == Color.Gray)
                {
                    input.Text = "";
                    input.ForeColor = Color.Black;
                }

                input.BackColor = focusBackColor;
                input.BorderStyle = BorderStyle.Fixed3D;
            };


            input.Leave += (sender, e) =>
            {

                if (string.IsNullOrWhiteSpace(input.Text))
                {
                    input.Text = placeholder;
                    input.ForeColor = Color.Gray;
                }

                input.BackColor = defaultBackColor;
                if (input.Text.Length == 0)
                {
                    input.BorderStyle = BorderStyle.None;
                }
            };
        }


        public static void ApplyStyleLabelWithIcon(Label label, IconChar icon, string title)
        {
            if (label == null || label.Parent == null)
                return;


            var container = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                Location = label.Location,
                WrapContents = false,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };


            var iconBox = new IconPictureBox
            {
                IconChar = icon,
                IconColor = label.ForeColor,
                IconSize = label.Font.Height + 4,
                BackColor = Color.Transparent,
                Size = new Size(label.Font.Height + 6, label.Font.Height + 6),
                Margin = new Padding(0, 0, 5, 0)
            };


            label.Text = title;
            label.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(50, 50, 50);
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.BackColor = Color.Transparent;
            label.Margin = new Padding(0, (iconBox.Height - label.Font.Height) / 2, 0, 0);


            var parent = label.Parent;


            parent.Controls.Remove(label);


            container.Controls.Add(label);
            container.Controls.Add(iconBox);



            parent.Controls.Add(container);
            container.BringToFront();
        }

        public static void ApplyStyleLable(Label label, string title)
        {
            label.Text = title;
            label.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(50, 50, 50);
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Margin = new Padding(0, 0, 0, 0);
        }

        public static void ApplyStyleDatePicker(DateTimePicker picker)
        {

            picker.CalendarForeColor = Color.Black;
            picker.CalendarMonthBackground = Color.White;
            picker.CalendarTitleBackColor = Color.FromArgb(0, 120, 215);
            picker.CalendarTitleForeColor = Color.White;
            picker.Width = 140;
            picker.Height = 50;

            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "dd/MM/yyyy";


            picker.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            picker.Padding = new Padding(8, 5, 8, 5);


            picker.ShowUpDown = false;


            picker.ForeColor = Color.FromArgb(33, 37, 41);


            picker.BackColor = Color.WhiteSmoke;





            picker.MouseEnter += (s, e) =>
            {
                picker.BackColor = Color.FromArgb(245, 245, 245);
            };
            picker.MouseLeave += (s, e) =>
            {
                picker.BackColor = Color.WhiteSmoke;
            };
        }

        public static void ApplyStyleCompoBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = Color.Black;
            comboBox.Font = new Font("Segoe UI", 10F);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.Margin = new Padding(0);
            comboBox.Padding = new Padding(4);


            comboBox.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, comboBox.Width, comboBox.Height, 6, 6)
            );


            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.DrawItem += (s, e) =>
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    string text = comboBox.Items[e.Index].ToString();
                    e.Graphics.DrawString(text, comboBox.Font, Brushes.Black, e.Bounds);
                }
                e.DrawFocusRectangle();
            };
        }

        public static void ApplyStyleRadioButton(RadioButton radio, string title)
        {
            if (radio == null) return;


            radio.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            radio.ForeColor = Color.FromArgb(50, 50, 50);
            radio.BackColor = Color.Transparent;
            radio.Text = title;

            radio.FlatStyle = FlatStyle.Flat;
            radio.FlatAppearance.BorderSize = 0;
            radio.AutoSize = true;
            radio.Cursor = Cursors.Hand;


            Color activeColor = Color.FromArgb(79, 64, 187);
            Color hoverColor = Color.FromArgb(230, 230, 250);
            Color normalColor = Color.Transparent;


            radio.MouseEnter += (s, e) =>
            {
                if (!radio.Checked)
                    radio.BackColor = hoverColor;
            };
            radio.MouseLeave += (s, e) =>
            {
                if (!radio.Checked)
                    radio.BackColor = normalColor;
            };


            radio.CheckedChanged += (s, e) =>
            {
                if (radio.Checked)
                {
                    radio.ForeColor = activeColor;
                    radio.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
                    radio.BackColor = Color.FromArgb(240, 240, 255);
                }
                else
                {
                    radio.ForeColor = Color.FromArgb(50, 50, 50);
                    radio.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    radio.BackColor = normalColor;
                }
            };
        }

        public static void ApplyStyleInvisibleGroupBox(GroupBox groupBox)
        {
            if (groupBox == null) return;

            groupBox.FlatStyle = FlatStyle.Flat;
            groupBox.BackColor = Color.Transparent;
            groupBox.ForeColor = Color.Transparent;
            groupBox.Text = "";


            groupBox.Paint += (s, e) =>
            {

                e.Graphics.Clear(groupBox.Parent.BackColor);
            };
        }



        public static void ApplyStyleTable(DataGridView table)
        {
            table.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            table.BorderStyle = BorderStyle.None;
            table.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            table.EnableHeadersVisualStyles = false;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table.MultiSelect = false;
            table.RowHeadersVisible = false;
            table.BackgroundColor = Color.White;
            table.GridColor = Color.FromArgb(240, 240, 240);


            table.ColumnHeadersDefaultCellStyle.BackColor = PRIMARY_COLOR;
            table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            table.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            table.ColumnHeadersHeight = 60;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

     
            table.DefaultCellStyle.BackColor = Color.White;
            table.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 245, 255); 
            table.DefaultCellStyle.ForeColor =Color.FromArgb(50, 50, 50);
            table.DefaultCellStyle.SelectionBackColor = Color.FromArgb(228, 214, 255);
            table.DefaultCellStyle.SelectionForeColor = Color.Black;
            table.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            table.RowTemplate.Height = 40;
            table.AllowUserToResizeRows = false;

        
            table.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            table.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

          
            table.ScrollBars = ScrollBars.Vertical;
        }
    }
}
