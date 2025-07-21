using System;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner;

namespace WinFormsAppfinalhwk
{
    public partial class ResetForm : Form
    {
        private readonly string userId;
        private readonly string email;
        private readonly string sentCode;

        public ResetForm(string userId, string email, string sentCode)
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

            this.userId = userId;
            this.email = email;
            this.sentCode = sentCode;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string inputCode = txtVerifyCode.Text.Trim();
            string newPwd = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(inputCode) || string.IsNullOrEmpty(newPwd))
            {
                MessageBox.Show("请输入验证码和新密码！");
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
                    string sql = "UPDATE Users SET Password=@Password WHERE UserId=@UserId";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPwd);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("密码重置成功！");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("密码重置失败！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置失败：" + ex.Message);
            }
        }
    }
}
