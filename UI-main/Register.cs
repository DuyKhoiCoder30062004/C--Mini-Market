using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1_C__25_26
{
    public partial class Register : Form
    {
        private readonly string connectionString =
        "Data Source=DESKTOP-JDBBM84\\SQLEXPRESS;Initial Catalog=Winforms_C#;User ID=khoiduy;Password=Crazybober@321;Encrypt=True;TrustServerCertificate=True;";
        public Register()
        {
            InitializeComponent();
            StyleUI();
        }

        private void StyleUI()
        {
            this.BackColor = Color.FromArgb(240, 240, 250);
            panelReg.BackColor = Color.White;

            btnRegister.BackColor = Color.MediumPurple;
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var check = new System.Net.Mail.MailAddress(email);
                return check.Address == email;
            }
            catch { return false; }
        }

        private bool IsStrongPassword(string pw)
        {
            if (pw.Length < 8) return false;
            if (!pw.Any(char.IsUpper)) return false;
            if (!pw.Any(char.IsLower)) return false;
            if (!pw.Any(char.IsDigit)) return false;
            if (!pw.Any(ch => "!@#$%^&*".Contains(ch))) return false;
            return true;
        }
        private bool UsernameExists(string username)
        {
            string sql = "SELECT COUNT(*) FROM Employees WHERE username = @u";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string u = txtUsername.Text.Trim();
            string p = txtPassword.Text;
            string eMail = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // Empty field check
            if (u == "" || p == "" || eMail == "" || fullName == "" || phone == "")
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Email validation
            if (!IsValidEmail(eMail))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Password strength
            if (!IsStrongPassword(p))
            {
                MessageBox.Show("Password must contain: 8 chars, 1 upper, 1 lower, 1 digit, 1 symbol.");
                return;
            }

            // Username duplicate check
            if (UsernameExists(u))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            // Hash password
            string hashed = HashPassword(p);

            // Insert query
            string query = @"
        INSERT INTO Employees (username, password, email, full_name, phone_number, role_id, is_archive)
        VALUES (@u, @p, @e, @f, @ph, 14, 0)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@u", u);
                cmd.Parameters.AddWithValue("@p", hashed);
                cmd.Parameters.AddWithValue("@e", eMail);
                cmd.Parameters.AddWithValue("@f", fullName);
                cmd.Parameters.AddWithValue("@ph", phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Account created successfully!");
            new Login().Show();
            this.Hide();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // 1. Create a new instance of the Login form
            Login loginForm = new Login();

            // 2. Display the Login form
            loginForm.Show();

            // 3. Hide the current Register form (or Close() it if you want to dispose of it)
            this.Hide();
        }
    }
}
