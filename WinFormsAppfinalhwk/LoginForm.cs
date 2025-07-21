using System;
using System.IO;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner;

namespace WinFormsAppfinalhwk
{
    public partial class LoginForm : Form
    {
        private readonly string autoLoginFile = "autologin.dat";

        public LoginForm()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen ?? Screen.AllScreens[0];
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;
            this.Size = new Size(screenWidth*2 / 3, screenHeight*2 / 3);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 设置窗体背景图片
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\WinFormApp\WinFormsAppfinalhwk\background1.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { }

            // 自动登录检测
            TryAutoLogin();
        }

        private void TryAutoLogin()
        {
            if (File.Exists(autoLoginFile))
            {
                try
                {
                    string[] lines = File.ReadAllLines(autoLoginFile);
                    if (lines.Length >= 2)
                    {
                        string userId = lines[0];
                        if (DateTime.TryParse(lines[1], out DateTime lastLogin))
                        {
                            if ((DateTime.Now - lastLogin).TotalDays <= 7)
                            {
                                chkAutoLogin.Checked = true;
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
                                            // 自动登录
                                            MainForm mainForm = new MainForm(userId);
                                            mainForm.Show();
                                            this.Hide();
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { /* 忽略异常，继续手动登录 */ }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入账号和密码！");
                return;
            }

            try
            {
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE UserId=@UserId AND Password=@Password";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Password", password);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            // 仅在勾选时保存自动登录信息
                            if (chkAutoLogin.Checked)
                                File.WriteAllLines(autoLoginFile, new string[] { userId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
                            else if (File.Exists(autoLoginFile))
                                File.Delete(autoLoginFile);

                            MessageBox.Show("登录成功！");
                            MainForm mainForm = new MainForm(userId);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("账号或密码错误！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败：" + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void btnForgotPwd_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("请先输入账号！");
                return;
            }

            try
            {
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Email FROM Users WHERE UserId=@UserId";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        var emailObj = cmd.ExecuteScalar();
                        if (emailObj != null && !string.IsNullOrEmpty(emailObj.ToString()))
                        {
                            string resetEmail = emailObj.ToString();
                            string resetCode = new Random().Next(100000, 999999).ToString();
                            if (SendResetEmail(resetEmail, resetCode))
                            {
                                MessageBox.Show("重置验证码已发送，请查收邮箱！");
                                // 弹出重置窗口
                                var resetForm = new ResetForm(userId, resetEmail, resetCode);
                                resetForm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("未找到该账号对应的邮箱！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送邮件失败：" + ex.Message);
            }
        }

        private bool SendResetEmail(string email, string code)
        {
            try
            {
                var smtpClient = new System.Net.Mail.SmtpClient("smtp.qq.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("2509442881@qq.com", "iqwzpxxpryjmeahg"),
                    EnableSsl = true,
                };

                var mailMessage = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress("2509442881@qq.com"),
                    Subject = "密码重置验证码",
                    Body = $"您的密码重置验证码为：{code}，请在重置窗口输入完成验证。",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送重置邮件失败：{ex.Message}");
                return false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
