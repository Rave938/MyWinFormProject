using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner; // 确保引用你的 DBHelper 命名空间

namespace WinFormsAppfinalhwk
{
    public partial class TaskForm : Form
    {
        private string userId;

        public TaskForm(string userId)
        {
            InitializeComponent();
            this.userId = userId;

            // 统一风格设置
            var screen = Screen.PrimaryScreen ?? Screen.AllScreens[0];
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;
            this.Size = new Size(screenWidth * 2 / 3, screenHeight * 2 / 3);
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\WinFormApp\WinFormsAppfinalhwk\background4.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { }

            EnsureTaskTable();
            LoadTasks();

            btnAddTask.Click += btnAddTask_Click;
            btnMarkToday.Click += btnMarkToday_Click;
            btnBatchComplete.Click += btnBatchComplete_Click;
        }

        /// <summary>
        /// 确保Tasks表存在
        /// </summary>
        private void EnsureTaskTable()
        {
            string createSql = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    UserId VARCHAR(50),
                    TaskName VARCHAR(100),
                    CourseName VARCHAR(100),
                    Deadline DATETIME,
                    Priority VARCHAR(20),
                    IsCompleted BIT
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            // 修正：直接在此实现表存在性检查和创建
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = $"SHOW TABLES LIKE 'Tasks'";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        using (var createCmd = new MySqlCommand(createSql, conn))
                        {
                            createCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void LoadTasks()
        {
            dgvTasks.Rows.Clear();
            dgvTasks.Columns.Clear();
            dgvTasks.Columns.Add("TaskName", "任务名");
            dgvTasks.Columns.Add("CourseName", "关联课程");
            dgvTasks.Columns.Add("Deadline", "截止时间");
            dgvTasks.Columns.Add("Priority", "优先级");
            dgvTasks.Columns.Add("IsCompleted", "完成状态");

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, TaskName, CourseName, Deadline, Priority, IsCompleted FROM Tasks WHERE UserId=@UserId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime deadline = reader["Deadline"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["Deadline"]);
                            bool isCompleted = reader["IsCompleted"] != DBNull.Value && Convert.ToBoolean(reader["IsCompleted"]);
                            int rowIndex = dgvTasks.Rows.Add(
                                reader["TaskName"]?.ToString() ?? "",
                                reader["CourseName"]?.ToString() ?? "",
                                deadline.ToString("yyyy-MM-dd HH:mm"),
                                reader["Priority"]?.ToString() ?? "",
                                isCompleted ? "已完成" : "未完成"
                            );
                            // 高亮今日未完成任务
                            if (!isCompleted && deadline.Date == DateTime.Now.Date)
                            {
                                dgvTasks.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                                dgvTasks.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;
                                dgvTasks.Rows[rowIndex].DefaultCellStyle.Font = new Font(dgvTasks.Font, FontStyle.Bold);
                            }
                            // 灰色显示已完成任务
                            if (isCompleted)
                            {
                                dgvTasks.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvTasks.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                            }
                        }
                    }
                }
            }
        }

        // 添加任务：弹窗输入
        private void btnAddTask_Click(object? sender, EventArgs e)
        {
            using (var dialog = new TaskAddDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var conn = DBHelper.GetConnection())
                    {
                        conn.Open();
                        string checkSql = "SELECT COUNT(*) FROM Tasks WHERE UserId=@UserId AND TaskName=@TaskName";
                        using (var cmd = new MySqlCommand(checkSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@TaskName", dialog.TaskTitle); // 修正属性名
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count == 0)
                            {
                                string insertSql = "INSERT INTO Tasks (UserId, TaskName, CourseName, Deadline, Priority, IsCompleted) VALUES (@UserId, @TaskName, @CourseName, @Deadline, @Priority, @IsCompleted)";
                                using (var insertCmd = new MySqlCommand(insertSql, conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@UserId", userId);
                                    insertCmd.Parameters.AddWithValue("@TaskName", dialog.TaskTitle); // 修正属性名
                                    insertCmd.Parameters.AddWithValue("@CourseName", dialog.RelatedCourse); // 修正属性名
                                    insertCmd.Parameters.AddWithValue("@Deadline", dialog.DueDate); // 修正属性名
                                    insertCmd.Parameters.AddWithValue("@Priority", dialog.PriorityLevel); // 修正属性名
                                    insertCmd.Parameters.AddWithValue("@IsCompleted", dialog.IsTaskCompleted); // 修正属性名
                                    insertCmd.ExecuteNonQuery();
                                }
                                LoadTasks();
                            }
                            else
                            {
                                MessageBox.Show("该任务已存在！");
                            }
                        }
                    }
                }
            }
        }

        // 标记今日完成：高亮今日未完成任务
        private void btnMarkToday_Click(object? sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTasks.Rows)
            {
                if (row.IsNewRow) continue;
                string deadlineStr = row.Cells[2].Value?.ToString() ?? "";
                string isCompletedStr = row.Cells[4].Value?.ToString() ?? "";
                if (DateTime.TryParse(deadlineStr, out DateTime deadline) && isCompletedStr == "未完成")
                {
                    if (deadline.Date == DateTime.Now.Date)
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.Font = new Font(dgvTasks.Font, FontStyle.Bold);
                    }
                }
            }
        }

        // 批量完成：将选中任务行标记为已完成，整行底色为灰色
        private void btnBatchComplete_Click(object? sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTasks.SelectedRows)
            {
                if (row.IsNewRow) continue;
                string taskName = row.Cells[0].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(taskName)) continue;
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Tasks SET IsCompleted=1 WHERE UserId=@UserId AND TaskName=@TaskName";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@TaskName", taskName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            LoadTasks();
        }

        // 修正后的“标记今日完成”按钮事件
        private void btnMarkTodayCompleted_Click(object sender, EventArgs e)
        {
            // 使用dgvTasks而不是dataGridViewTasks
            if (dgvTasks.SelectedRows.Count == 0) return;

            var row = dgvTasks.SelectedRows[0];
            string taskName = row.Cells[0].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(taskName)) return;

            // 更新数据库中该任务的完成状态
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Tasks SET IsCompleted=1 WHERE UserId=@UserId AND TaskName=@TaskName";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@TaskName", taskName);
                    cmd.ExecuteNonQuery();
                }
            }

            // 只高亮当前选中行，不刷新全部
            row.Cells["IsCompleted"].Value = "已完成";
            row.DefaultCellStyle.BackColor = Color.LightGreen;
            row.DefaultCellStyle.ForeColor = Color.Black;
            row.DefaultCellStyle.Font = new Font(dgvTasks.Font, FontStyle.Bold);
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {

        }
    }
}
