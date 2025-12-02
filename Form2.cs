//using System;
//using System.Drawing;
//using System.Windows.Forms;
//now - Hiệp

//namespace WinFormsApp1_C__25_26
//{
//    public partial class Form2 : Form
//    {
//        private bool isDarkMode = false; // Default: Light mode

//        public Form2()
//        {
//            InitializeComponent();
//            InitializeUI();
//        }

//        private void InitializeUI()
//        {
//            this.Text = "Dark Mode Switch Example";
//            this.Size = new Size(400, 300);

//            Button toggleButton = new Button();
//            toggleButton.Text = "Switch to Dark Mode";
//            toggleButton.Location = new Point(120, 100);
//            toggleButton.AutoSize = true;
//            toggleButton.Click += ToggleButton_Click;

//            this.Controls.Add(toggleButton);
//            ApplyTheme(isDarkMode);
//        }

//        private void ToggleButton_Click(object sender, EventArgs e)
//        {
//            isDarkMode = !isDarkMode;
//            ApplyTheme(isDarkMode);

//            Button btn = sender as Button;
//            btn.Text = isDarkMode ? "Switch to Light Mode" : "Switch to Dark Mode";
//        }

//        private void ApplyTheme(bool dark)
//        {
//            Color backColor, foreColor, buttonColor;

//            if (dark)
//            {
//                backColor = Color.FromArgb(30, 30, 30);    // dark background
//                foreColor = Color.WhiteSmoke;               // light text
//                buttonColor = Color.FromArgb(60, 60, 60);   // dark button
//            }
//            else
//            {
//                backColor = SystemColors.Control;
//                foreColor = Color.Black;
//                buttonColor = SystemColors.ControlLight;
//            }

//            this.BackColor = backColor;
//            this.ForeColor = foreColor;

//            // Apply to all controls recursively
//            foreach (Control ctrl in this.Controls)
//            {
//                ApplyThemeToControl(ctrl, dark, backColor, foreColor, buttonColor);
//            }
//        }
//        private void label1_Click(object sender, EventArgs e)
//        {
//            // You can leave this empty if you don't need it
//        }
//        private void ApplyThemeToControl(Control ctrl, bool dark, Color back, Color fore, Color button)
//        {
//            if (ctrl is Button)
//            {
//                ctrl.BackColor = button;
//                ctrl.ForeColor = fore;
//                ((Button)ctrl).FlatStyle = FlatStyle.Flat;
//                ((Button)ctrl).FlatAppearance.BorderColor = dark ? Color.Gray : Color.DarkGray;
//            }
//            else if (ctrl is TextBox)
//            {
//                ctrl.BackColor = dark ? Color.FromArgb(50, 50, 50) : Color.White;
//                ctrl.ForeColor = fore;
//                ((TextBox)ctrl).BorderStyle = BorderStyle.FixedSingle;
//            }
//            else
//            {
//                ctrl.BackColor = back;
//                ctrl.ForeColor = fore;
//            }

//            // Recursive for nested controls (like Panels, GroupBoxes)
//            foreach (Control child in ctrl.Controls)
//                ApplyThemeToControl(child, dark, back, fore, button);
//        }
//    }
//}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1_C__25_26
{
    public partial class Form2 : Form
    {
        private Panel sidebar;
        private Panel mainPanel;
        private Button btnDashboard, btnProducts, btnInventory, btnSales, btnInvoice, btnToggleTheme;
        private bool isDarkMode = false;

        public Form2()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Mini Market System";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Sidebar
            sidebar = new Panel()
            {
                Dock = DockStyle.Left,
                Width = 180,
                BackColor = Color.WhiteSmoke,
            };
            this.Controls.Add(sidebar);

            // Main panel
            mainPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
            };
            this.Controls.Add(mainPanel);

            // Sidebar buttons
            btnDashboard = CreateSidebarButton("Dashboard");
            btnProducts = CreateSidebarButton("Products");
            btnInventory = CreateSidebarButton("Inventory");
            btnSales = CreateSidebarButton("Sales");
            btnInvoice = CreateSidebarButton("Invoice");
            btnToggleTheme = CreateSidebarButton("🌙 Toggle Theme");

            // Add to sidebar
            sidebar.Controls.AddRange(new Control[]
            {
                btnDashboard, btnProducts, btnInventory, btnSales, btnInvoice, btnToggleTheme
            });

            // Position buttons
            int y = 30;
            foreach (Control c in sidebar.Controls)
            {
                c.Top = y;
                y += 45;
            }

            // Event
            btnToggleTheme.Click += ToggleTheme;
        }

        private Button CreateSidebarButton(string text)
        {
            var btn = new Button()
            {
                Text = text,
                Dock = DockStyle.None,
                Width = 160,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.Black,
                BackColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Left = 10;

            // Hover effect
            btn.MouseEnter += (s, e) =>
            {
                if (!isDarkMode)
                    btn.BackColor = Color.FromArgb(230, 220, 255); // light purple hover
                else
                    btn.BackColor = Color.FromArgb(80, 60, 120);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = isDarkMode ? Color.FromArgb(40, 40, 40) : Color.WhiteSmoke;
            };

            return btn;
        }

        private void ToggleTheme(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;

            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                sidebar.BackColor = Color.FromArgb(40, 40, 40);
                mainPanel.BackColor = Color.FromArgb(20, 20, 20);
                foreach (Button b in sidebar.Controls)
                {
                    b.BackColor = Color.FromArgb(40, 40, 40);
                    b.ForeColor = Color.White;
                }
            }
            else
            {
                this.BackColor = Color.White;
                sidebar.BackColor = Color.WhiteSmoke;
                mainPanel.BackColor = Color.White;
                foreach (Button b in sidebar.Controls)
                {
                    b.BackColor = Color.WhiteSmoke;
                    b.ForeColor = Color.Black;
                }
            }
        }
    }
}

