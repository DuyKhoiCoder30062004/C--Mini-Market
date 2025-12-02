namespace WinFormsApp1_C__25_26
{
    partial class Register
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelReg;
        private Label lblTitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private Label lblUser;
        private Label lblPass;
        private Label lblEmail;
        private Label lblFullName;
        private Button btnRegister;
        private Label lblPhone;
        private TextBox txtPhone;
        private CheckBox chkShowPassword;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelReg = new Panel();
            lblTitle = new Label();
            lblFullName = new Label(); // Changed order for better flow
            txtFullName = new TextBox(); // Changed order for better flow
            lblUser = new Label();
            txtUsername = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox(); // Added
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label(); // Added
            txtPhone = new TextBox(); // Added
            btnRegister = new Button();
            btnBack = new Button(); // Added

            panelReg.SuspendLayout();
            SuspendLayout();

            // 
            // panelReg
            // 
            panelReg.Controls.Add(lblTitle);
            panelReg.Controls.Add(lblFullName);
            panelReg.Controls.Add(txtFullName);
            panelReg.Controls.Add(lblUser);
            panelReg.Controls.Add(txtUsername);
            panelReg.Controls.Add(lblPass);
            panelReg.Controls.Add(txtPassword);
            panelReg.Controls.Add(chkShowPassword);
            panelReg.Controls.Add(lblEmail);
            panelReg.Controls.Add(txtEmail);
            panelReg.Controls.Add(lblPhone);
            panelReg.Controls.Add(txtPhone);
            panelReg.Controls.Add(btnRegister);
            panelReg.Controls.Add(btnBack);
            panelReg.Location = new Point(170, 50); // Center the panel better
            panelReg.Name = "panelReg";
            panelReg.Size = new Size(330, 500); // FIXED: Increased size to accommodate all fields
            panelReg.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(80, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Account";

            // 
            // lblFullName
            // 
            lblFullName.Location = new Point(30, 60);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(100, 23);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(30, 80);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(270, 23);
            txtFullName.TabIndex = 2;

            // 
            // lblUser
            // 
            lblUser.Location = new Point(30, 115);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(100, 23);
            lblUser.TabIndex = 3;
            lblUser.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(30, 135);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(270, 23);
            txtUsername.TabIndex = 4;

            // 
            // lblPass
            // 
            lblPass.Location = new Point(30, 170);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(100, 23);
            lblPass.TabIndex = 5;
            lblPass.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(30, 190);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(270, 23);
            txtPassword.TabIndex = 6;

            //
            // chkShowPassword
            //
            chkShowPassword.Location = new Point(30, 220);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Text = "Show Password";
            chkShowPassword.Size = new Size(150, 23);
            chkShowPassword.TabIndex = 7;
            // The actual logic for CheckedChanged is now in Register.cs (or the old lambda is fine, but cleaner to move the event hookup)


            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(30, 255);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 275);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(270, 23);
            txtEmail.TabIndex = 9;

            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(30, 310);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(30, 330);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(270, 23);
            txtPhone.TabIndex = 11;

            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(30, 370);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(270, 35);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Create Account";
            btnRegister.Click += btnRegister_Click;

            // 
            // btnBack
            // 
            btnBack.Location = new Point(30, 415);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(270, 30);
            btnBack.TabIndex = 13;
            btnBack.Text = "Back to Login";
            btnBack.Click += btnBack_Click; // Added explicit event handler

            // 
            // Register
            // 
            ClientSize = new Size(671, 580); // Adjusted total form size to fit the panel
            Controls.Add(panelReg);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            panelReg.ResumeLayout(false);
            panelReg.PerformLayout();
            ResumeLayout(false);
        }
        private Label label1; // Cleaned up redundant declarations
        private TextBox textBox1;
    }
}
