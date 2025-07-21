using System;
using System.Net.Mail;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner;

namespace WinFormsAppfinalhwk
{
    public partial class RegisterForm : Form
    {
        private string sentCode = ""; // 保存已发送的验证码

        public RegisterForm()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen ?? Screen.AllScreens[0];
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;
            this.Size = new Size(screenWidth * 2 / 3, screenHeight * 2 / 3);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 设置窗体背景图片
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\WinFormApp\WinFormsAppfinalhwk\background1.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                // 图片不存在时不设置背景
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // 可在此初始化控件或加载数据
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show("请输入有效的邮箱地址！");
                return;
            }

            // 生成验证码
            sentCode = new Random().Next(100000, 999999).ToString();
            if (SendVerificationEmail(email, sentCode))
            {
                MessageBox.Show("验证码已发送，请查收邮箱！");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string inputCode = txtVerifyCode.Text.Trim();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(inputCode))
            {
                MessageBox.Show("请填写所有字段并输入验证码！");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("请输入有效的邮箱地址！");
                return;
            }

            if (inputCode != sentCode)
            {
                MessageBox.Show("验证码错误！");
                return;
            }

            try
            {
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();

                    // 检查ID是否重复
                    string checkIdQuery = "SELECT COUNT(*) FROM Users WHERE UserId = @UserId";
                    using (var cmd = new MySqlCommand(checkIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("用户ID已存在！");
                            return;
                        }
                    }

                    // 检查Email是否重复
                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (var cmd = new MySqlCommand(checkEmailQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("邮箱已被注册！");
                            return;
                        }
                    }

                    // 插入新用户
                    string insertQuery = "INSERT INTO Users (UserId, Email, Password) VALUES (@UserId, @Email, @Password)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("注册成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"注册失败：{ex.Message}");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool SendVerificationEmail(string email, string code)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.qq.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("2509442881@qq.com", "iqwzpxxpryjmeahg"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("2509442881@qq.com"),
                    Subject = "注册验证码",
                    Body = $"您的注册验证码为：{code}，请在注册界面输入完成验证。",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送验证码失败：{ex.Message}");
                return false;
            }
        }

        private void RegisterForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
