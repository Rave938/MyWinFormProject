using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner;

namespace WinFormsAppfinalhwk
{
    public partial class GroupForm : Form
    {
        private string userId;
        public GroupForm(string userId)
        {
            InitializeComponent();
            this.userId = userId;
            EnsureGroupTable();
            InitListViewColumns();
            LoadGroups();

            btnCreateGroupTask.Click += btnCreateGroupTask_Click;

            // 统一风格设置
            var screen = Screen.PrimaryScreen ?? Screen.AllScreens[0];
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;
            this.Size = new Size(screenWidth / 2, screenHeight / 2);
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\WinFormApp\WinFormsAppfinalhwk\background.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { }
        }

        /// <summary>
        /// 确保Groups表存在（用反引号避免MySQL保留字冲突）
        /// </summary>
        private void EnsureGroupTable()
        {
            string createSql = @"
                CREATE TABLE IF NOT EXISTS `Groups` (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    UserId VARCHAR(50),
                    GroupName VARCHAR(100),
                    MemberCount INT DEFAULT 1,
                    TodayPunchCount INT DEFAULT 0
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SHOW TABLES LIKE 'Groups'";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        using (var createCmd = new MySqlCommand(createSql, conn))
                        {
                            try
                            {
                                createCmd.ExecuteNonQuery();
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show("创建Groups表失败：" + ex.Message, "数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 初始化ListView列
        /// </summary>
        private void InitListViewColumns()
        {
            lvGroups.View = View.Details;
            lvGroups.FullRowSelect = true;
            lvGroups.GridLines = true;
            if (lvGroups.Columns.Count == 0)
            {
                lvGroups.Columns.Add("小组名称", 120);
                lvGroups.Columns.Add("成员数", 80);
                lvGroups.Columns.Add("今日打卡数", 100);
            }
        }

        /// <summary>
        /// 加载小组数据到lvGroups
        /// </summary>
        private void LoadGroups()
        {
            lvGroups.Items.Clear();
            if (lvGroups.Columns.Count == 0)
                InitListViewColumns();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT GroupName, MemberCount, TodayPunchCount FROM `Groups` WHERE UserId=@UserId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ListViewItem(reader["GroupName"]?.ToString() ?? "");
                            item.SubItems.Add(reader["MemberCount"]?.ToString() ?? "");
                            item.SubItems.Add(reader["TodayPunchCount"]?.ToString() ?? "");
                            lvGroups.Items.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 创建小组任务
        /// </summary>
        private void btnCreateGroupTask_Click(object? sender, EventArgs e)
        {
            EnsureGroupTable();
            string groupName = Microsoft.VisualBasic.Interaction.InputBox("小组名称：", "创建小组");
            if (string.IsNullOrWhiteSpace(groupName)) return;

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM `Groups` WHERE UserId=@UserId AND GroupName=@GroupName";
                using (var cmd = new MySqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@GroupName", groupName);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertSql = "INSERT INTO `Groups` (UserId, GroupName, MemberCount, TodayPunchCount) VALUES (@UserId, @GroupName, 1, 0)";
                        using (var insertCmd = new MySqlCommand(insertSql, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@UserId", userId);
                            insertCmd.Parameters.AddWithValue("@GroupName", groupName);
                            insertCmd.ExecuteNonQuery();
                        }
                        LoadGroups();
                    }
                    else
                    {
                        MessageBox.Show("该小组已存在！");
                    }
                }
            }
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            // 可选：窗体加载时刷新小组列表
            LoadGroups();
        }
    }
}
