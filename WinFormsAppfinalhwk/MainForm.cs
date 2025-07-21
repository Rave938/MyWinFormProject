using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner;

namespace WinFormsAppfinalhwk
{
    public partial class MainForm : Form
    {
        private string currentUserId;
        private DateTime studyStartTime;

        public MainForm(string userId)
        {
            InitializeComponent();
            currentUserId = userId;
            if (lblUser != null)
                lblUser.Text = $"当前用户：{userId}";
            if (timer1 != null)
                timer1.Start();
            studyStartTime = DateTime.Now;

            // 统一风格设置
            var screen = Screen.PrimaryScreen ?? Screen.AllScreens[0];
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;
            this.Size = new Size(screenWidth * 2 / 3, screenHeight * 2 / 3);
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\WinFormApp\WinFormsAppfinalhwk\background3.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { }

            // 快捷按钮事件
            if (btnTodayTask != null)
                btnTodayTask.Click += btnTodayTask_Click;
            if (btnUpcomingExam != null)
                btnUpcomingExam.Click += btnUpcomingExam_Click;

            // 关闭事件
            this.FormClosed += MainForm_FormClosed;

            // 学习计划按钮事件（如有）
            if (btnStudyPlanner != null)
                btnStudyPlanner.Click += btnStudyPlanner_Click;
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            if (lblTime != null)
                lblTime.Text = $"系统时间：{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            // 学习时长统计
            TimeSpan span = DateTime.Now - studyStartTime;
            if (lblStudyTime != null)
                lblStudyTime.Text = $"学习时长：{span.Hours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";
        }

        private void menuCourse_Click(object? sender, EventArgs e)
        {
            new CourseForm(currentUserId).ShowDialog();
        }

        private void menuTask_Click(object? sender, EventArgs e)
        {
            new TaskForm(currentUserId).ShowDialog();
        }

        private void menuExam_Click(object? sender, EventArgs e)
        {
            new ExamForm(currentUserId).ShowDialog();
        }

        private void menuNote_Click(object? sender, EventArgs e)
        {
            new NoteForm(currentUserId).ShowDialog();
        }

        private void menuGroup_Click(object? sender, EventArgs e)
        {
            new GroupForm(currentUserId).ShowDialog();
        }

        // 快捷按钮：今日待办
        private void btnTodayTask_Click(object? sender, EventArgs e)
        {
            new TaskForm(currentUserId).ShowDialog();
        }

        // 快捷按钮：最近考试
        private void btnUpcomingExam_Click(object? sender, EventArgs e)
        {
            new ExamForm(currentUserId).ShowDialog();
        }

        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            // 可扩展：加载统计数据等
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            // 清除自动登录信息
            string autoLoginFile = "autologin.dat";
            if (System.IO.File.Exists(autoLoginFile))
                System.IO.File.Delete(autoLoginFile);

            // 返回登录界面
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        // 学习计划按钮事件
        private void btnStudyPlanner_Click(object? sender, EventArgs e)
        {
            List<TodoItem> todayTodos = null;
            List<ExamItem> upcomingExams = null;
            try
            {
                todayTodos = GetTodayTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取今日待办失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                todayTodos = new List<TodoItem>();
            }
            try
            {
                upcomingExams = GetUpcomingExams();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取考试信息失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                upcomingExams = new List<ExamItem>();
            }
            new StudyingPlanner(todayTodos ?? new List<TodoItem>(), upcomingExams ?? new List<ExamItem>()).ShowDialog();
        }

        // 获取今日待办
        private List<TodoItem> GetTodayTodos()
        {
            var list = new List<TodoItem>();
            try
            {
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT TaskName, CourseName, Deadline, Priority FROM Tasks WHERE UserId=@UserId AND IsCompleted=0";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime due = DateTime.Now;
                                if (!(reader["Deadline"] is DBNull) && !DateTime.TryParse(reader["Deadline"].ToString(), out due))
                                {
                                    due = DateTime.Now;
                                }
                                if (due.Date == DateTime.Now.Date)
                                {
                                    list.Add(new TodoItem
                                    {
                                        TaskContent = reader["TaskName"]?.ToString() ?? "",
                                        Subject = reader["CourseName"]?.ToString() ?? "",
                                        DueDate = due,
                                        Priority = reader["Priority"]?.ToString() ?? "中",
                                        IsComplex = false
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取今日待办异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        // 获取最近考试
        private List<ExamItem> GetUpcomingExams()
        {
            var list = new List<ExamItem>();
            try
            {
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Subject, ExamDate, Importance, KeyTopics FROM Exams WHERE UserId=@UserId";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime examDate = DateTime.Now;
                                if (!(reader["ExamDate"] is DBNull) && !DateTime.TryParse(reader["ExamDate"].ToString(), out examDate))
                                {
                                    examDate = DateTime.Now;
                                }
                                int days = (examDate.Date - DateTime.Now.Date).Days;
                                if (days >= 0 && days <= 14)
                                {
                                    list.Add(new ExamItem
                                    {
                                        Subject = reader["Subject"]?.ToString() ?? "",
                                        DaysUntilExam = days,
                                        Importance = reader["Importance"]?.ToString() ?? "中",
                                        KeyTopics = reader["KeyTopics"]?.ToString() ?? ""
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取考试信息异常：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        // 打开学习计划按钮事件
        private void btnOpenPlanner_Click(object? sender, EventArgs e)
        {
            List<TodoItem> todayTodos = null;
            List<ExamItem> upcomingExams = null;
            try
            {
                todayTodos = GetTodayTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取今日待办失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                todayTodos = new List<TodoItem>();
            }
            try
            {
                upcomingExams = GetUpcomingExams();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取考试信息失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                upcomingExams = new List<ExamItem>();
            }
            if ((todayTodos != null && todayTodos.Count > 0) || (upcomingExams != null && upcomingExams.Count > 0))
            {
                var plannerForm = new StudyingPlanner(todayTodos ?? new List<TodoItem>(), upcomingExams ?? new List<ExamItem>());
                plannerForm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("暂无待办事项或考试数据，无法生成学习计划", "提示");
            }
        }

        private void btnUpcomingExam_Click_1(object sender, EventArgs e)
        {

        }
    }
}