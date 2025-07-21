using System;
using System.IO;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner;

namespace WinFormsAppfinalhwk
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2); // 关键：高DPI感知
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string autoLoginFile = "autologin.dat";
            bool autoLoginSuccess = false;
            string userId = "";

            if (File.Exists(autoLoginFile))
            {
                try
                {
                    string[] lines = File.ReadAllLines(autoLoginFile);
                    if (lines.Length >= 2)
                    {
                        userId = lines[0];
                        if (DateTime.TryParse(lines[1], out DateTime lastLogin))
                        {
                            if ((DateTime.Now - lastLogin).TotalDays <= 7)
                            {
                                // 检查用户是否存在
                                using (var conn = DBHelper.GetConnection())
                                {
                                    conn.Open();
                                    string sql = "SELECT COUNT(*) FROM Users WHERE UserId=@UserId";
                                    using (var cmd = new MySqlCommand(sql, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@UserId", userId);
                                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                                        if (count > 0)
                                        {
                                            autoLoginSuccess = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            if (autoLoginSuccess)
            {
                Application.Run(new MainForm(userId));
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }
}