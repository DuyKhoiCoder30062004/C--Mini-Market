using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStore.CoreUI
{
    public partial class ButtonLogout : UserControl
    {
        public ButtonLogout()
        {
            InitializeComponent();
            var buttonLogout = CreateButton("Đăng xuất", IconChar.RightFromBracket);
             this.Controls.Add(buttonLogout);
            this.BackColor = Color.FromArgb(79, 64, 187);
        }
        private Button CreateButton(string title, IconChar icon)
        {
            var btn = new IconButton();
            btn.Text = title;
            btn.IconChar = icon;
            btn.IconColor = Color.White;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;

            btn.IconSize = 20;
            btn.Height = 45;
            btn.Width =280;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.BackColor = Color.Transparent;
            btn.Margin = new Padding(0, 0, 0, 5);


            btn.Padding = new Padding(15, 0, 0, 0);
            Color normalColor = Color.Transparent;
            Color hoverColor = ColorTranslator.FromHtml("#5b4ee3");
            Color activeColor = ColorTranslator.FromHtml("#4f40bb");


            Panel leftBorder = new Panel
            {
                Size = new Size(5, btn.Height),
                BackColor = Color.White,
                Visible = false,
                Dock = DockStyle.Left
            };
            btn.Controls.Add(leftBorder);


            btn.MouseEnter += (s, e) =>
            {
               
                    btn.BackColor = hoverColor;
            };
            btn.MouseLeave += (s, e) =>
            {
             
                    btn.BackColor = normalColor;
            };


            btn.Click += (s, e) =>
            {
              
            };
            return btn;
        }

        private void ButtonLogout_Load(object sender, EventArgs e)
        {

        }
    }
}
