using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1_C__25_26
{
    public partial class Login : Form
    {
        private readonly string connectionString =
        "Data Source=DESKTOP-JDBBM84\\SQLEXPRESS;Initial Catalog=Winforms_C#;User ID=khoiduy;Password=Crazybober@321;Encrypt=True;TrustServerCertificate=True;";
        public Login()
        {
            InitializeComponent();
            StyleUI();
        }

        private void StyleUI()
        {
            this.BackColor = Color.FromArgb(245, 245, 255);
            panelLogin.BackColor = Color.White;
            panelLogin.BorderStyle = BorderStyle.FixedSingle;

            foreach (var txt in new TextBox[] { txtUsername, txtPassword })
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10);
            }

            btnLogin.BackColor = Color.FromArgb(110, 90, 200);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;

            btnRegister.BackColor = Color.FromArgb(230, 230, 255);
            btnRegister.ForeColor = Color.FromArgb(80, 50, 150);
            btnRegister.FlatStyle = FlatStyle.Flat;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] byteHash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in byteHash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password!");
                return;
            }

            string hash = HashPassword(password);

            string query = @"
        SELECT employee_id, role_id 
        FROM Employees 
        WHERE username = @u AND password = @p AND is_archive = 0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", hash); // Use hashed password

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int empId = reader.GetInt32(0);
                        int roleId = reader.GetInt32(1);

                        MessageBox.Show("Login successful!");

                        Form2 main = new Form2();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credentials!");
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }
    }
}
