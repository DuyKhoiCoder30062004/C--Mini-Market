using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStore.CoreUI
{
    public partial class App : Form
    {
        private IconButton currentActiveButton = null;
        private  List<MenuItem> _menuItems {  get; set; }
        public List<MenuItem> MenuItems { set { _menuItems = value; } }
        private FlowLayoutPanel MenuContainer = new FlowLayoutPanel();
        public App()
        {
            InitializeComponent();
           
        }

        public void StartAppUI()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "MiniStore";
            this.DoubleBuffered = true;
            splitContainer1.SplitterDistance = 280;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.BackColor = splitContainer1.Panel1.BackColor;

            MenuContainer.FlowDirection = FlowDirection.TopDown; 
            MenuContainer.WrapContents = false;                  
            MenuContainer.AutoScroll = true;                   
            MenuContainer.Dock = DockStyle.Left;
            MenuContainer.Padding = new Padding(0, 0, 0, 0);    
            MenuContainer.BackColor = Color.FromArgb(79, 64, 187);
            MenuContainer.Width = 280;
            MenuContainer.Height = 600;

            PanelInforUser panelInforUser = new PanelInforUser();
            panelInforUser.Dock = DockStyle.Top;
            panelInforUser.Height = 100;

            ButtonLogout buttonLogout = new ButtonLogout();
            buttonLogout.Dock = DockStyle.Bottom; 

            MenuContainer.Dock = DockStyle.Fill;

            splitContainer1.Panel1.Controls.Add(MenuContainer);
            splitContainer1.Panel1.Controls.Add(buttonLogout); 
            splitContainer1.Panel1.Controls.Add(panelInforUser);
          

            AddSidebarButtons(_menuItems);
            var btnHome = MenuContainer.Controls.OfType<IconButton>().FirstOrDefault();


           
        }

        public void AddSidebarButtons(List<MenuItem> menu)
        {
          
           foreach (MenuItem item in menu) 
            {
                var btn = CreateButton(item);
                MenuContainer.Controls.Add(btn);
            }
           
        }

        private Button CreateButton(MenuItem menuItem)
        {
            var btn = new IconButton();
            btn.Text = menuItem.Title;
            btn.IconChar = menuItem.IconChar;
            btn.IconColor = Color.White;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;

            btn.IconSize = 20;
            btn.Height = 55;
            btn.Width = MenuContainer.Width;
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
                if (btn != currentActiveButton)
                    btn.BackColor = hoverColor;
            };
            btn.MouseLeave += (s, e) =>
            {
                if (btn != currentActiveButton)
                    btn.BackColor = normalColor;
            };


            btn.Click += (s, e) =>
            {
                if (currentActiveButton != null)
                {
                    var oldBorder = currentActiveButton.Controls.OfType<Panel>().FirstOrDefault();
                    if (oldBorder != null) oldBorder.Visible = false;

                    currentActiveButton.BackColor = normalColor;
                    currentActiveButton.IconColor = Color.White;
                }

                btn.BackColor = activeColor;
                btn.IconColor = Color.WhiteSmoke;
                leftBorder.Visible = true;
                currentActiveButton = btn;
                SetContentPanel(menuItem.Content);
            };
            return btn;
        }

        private void SetContentPanel(UserControl content)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(content);
        }

        private void App_Load(object sender, EventArgs e)
        {
            var btnHome = MenuContainer.Controls.OfType<IconButton>().FirstOrDefault();
            if (btnHome != null)
            {
                btnHome.PerformClick();
            }
        }

      
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
      
        }
    }

   
}
