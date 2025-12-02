namespace WinFormsApp1_C__25_26
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelLogin;
        private Label lblTitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblUser;
        private Label lblPass;
        private Button btnLogin;
        private Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelLogin = new Panel();
            lblTitle = new Label();
            lblUser = new Label();
            txtUsername = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(lblTitle);
            panelLogin.Controls.Add(lblUser);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(lblPass);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(btnRegister);
            panelLogin.Location = new Point(300, 300);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(330, 300);
            panelLogin.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(70, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(203, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Mini Market Login";
            // 
            // lblUser
            // 
            lblUser.Location = new Point(30, 80);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(100, 23);
            lblUser.TabIndex = 1;
            lblUser.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(30, 100);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 23);
            txtUsername.TabIndex = 2;
            // 
            // lblPass
            // 
            lblPass.Location = new Point(30, 150);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(100, 23);
            lblPass.TabIndex = 3;
            lblPass.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(30, 170);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(30, 220);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 35);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(30, 260);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(250, 30);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;
            // 
            // Login
            // 
            ClientSize = new Size(700, 585);
            Controls.Add(panelLogin);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }
    }
}
