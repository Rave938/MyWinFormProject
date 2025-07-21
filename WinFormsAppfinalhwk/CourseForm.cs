using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using StudyPlanner; // 确保引用你的 DBHelper 命名空间

namespace WinFormsAppfinalhwk
{
    public partial class CourseForm : Form
    {
        private string userId;

        public CourseForm(string userId)
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

            EnsureCourseTable();
            LoadCourses();

            btnAddCourse.Click += btnAddCourse_Click;
            btnImport.Click += btnImport_Click;
            btnDeleteCourse.Click += btnDeleteCourse_Click;
        }

        private void EnsureCourseTable()
        {
            string createSql = @"
                CREATE TABLE IF NOT EXISTS Courses (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    UserId VARCHAR(50),
                    CourseName VARCHAR(100),
                    Credit INT,
                    ClassTime VARCHAR(100),
                    Difficulty VARCHAR(20)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = $"SHOW TABLES LIKE 'Courses'";
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

        private void LoadCourses()
        {
            dgvCourses.Rows.Clear();
            dgvCourses.Columns.Clear();
            dgvCourses.Columns.Add("CourseName", "课程名");
            dgvCourses.Columns.Add("Credit", "学分");
            dgvCourses.Columns.Add("ClassTime", "上课时间");
            dgvCourses.Columns.Add("Difficulty", "难度");

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT CourseName, Credit, ClassTime, Difficulty FROM Courses WHERE UserId=@UserId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvCourses.Rows.Add(
                                reader["CourseName"]?.ToString() ?? "",
                                reader["Credit"]?.ToString() ?? "",
                                reader["ClassTime"]?.ToString() ?? "",
                                reader["Difficulty"]?.ToString() ?? ""
                            );
                        }
                    }
                }
            }
        }

        private void btnAddCourse_Click(object? sender, EventArgs e)
        {
            EnsureCourseTable();
            string courseName = txtCourseName.Text.Trim();
            int credit = (int)nudCredit.Value;
            string classTime = txtClassTime.Text.Trim();
            string difficulty = cbDifficulty.Text;

            if (string.IsNullOrWhiteSpace(courseName) || string.IsNullOrWhiteSpace(classTime) || string.IsNullOrWhiteSpace(difficulty))
            {
                MessageBox.Show("请填写完整课程信息！");
                return;
            }

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM Courses WHERE UserId=@UserId AND CourseName=@CourseName";
                using (var cmd = new MySqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertSql = "INSERT INTO Courses (UserId, CourseName, Credit, ClassTime, Difficulty) VALUES (@UserId, @CourseName, @Credit, @ClassTime, @Difficulty)";
                        using (var insertCmd = new MySqlCommand(insertSql, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@UserId", userId);
                            insertCmd.Parameters.AddWithValue("@CourseName", courseName);
                            insertCmd.Parameters.AddWithValue("@Credit", credit);
                            insertCmd.Parameters.AddWithValue("@ClassTime", classTime);
                            insertCmd.Parameters.AddWithValue("@Difficulty", difficulty);
                            insertCmd.ExecuteNonQuery();
                        }
                        LoadCourses();
                    }
                    else
                    {
                        MessageBox.Show("该课程已存在！");
                    }
                }
            }
        }

        private void btnImport_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("导入课表功能待实现。");
        }

        private void btnDeleteCourse_Click(object? sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count == 0) return;
            var selectedRow = dgvCourses.SelectedRows[0];
            if (selectedRow?.Cells[0]?.Value == null)
            {
                MessageBox.Show("请选择要删除的课程。");
                return;
            }
            string? courseName = selectedRow.Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(courseName)) return;

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Courses WHERE UserId=@UserId AND CourseName=@CourseName";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadCourses();
        }

        private void CourseForm_Load(object? sender, EventArgs e)
        {

        }

        private void lblDifficulty_Click(object sender, EventArgs e)
        {

        }

        private void CourseForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
