using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Commom.Config
{
    public class AppDbConnect
    {
        private static readonly string _connectionString =
            "Server=localhost;Database=mini_store;User Id=root;Password=;";
        public static MySqlConnection GetConnection()
        {
            try
            {
                var conn = new MySqlConnection(_connectionString);

              
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến database.\nChi tiết: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static bool TestConnection()
        {
            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                string message =
                    "⚠️ Không thể kết nối đến cơ sở dữ liệu!\n\n" +
                    "Vui lòng kiểm tra lại các thông tin sau:\n" +
                    "• MySQL Server đã khởi động chưa?\n" +
                    "• Thông tin đăng nhập (User / Password) có chính xác không?\n" +
                    "• Tên cơ sở dữ liệu có tồn tại không?\n\n" +
                    $"Chi tiết lỗi kỹ thuật:\n{ex.Message}";

                DialogResult result = MessageBox.Show(
                    message,
                    "❌ Lỗi kết nối MySQL",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );

              
                if (result == DialogResult.Retry)
                {
                    return TestConnection(); 
                }

           
                Application.Exit();
                Environment.Exit(1);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi không xác định:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
                Application.Exit();
                Environment.Exit(1);
                return false;
            }
        }

    }
}
