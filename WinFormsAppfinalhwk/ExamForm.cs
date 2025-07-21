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
using StudyPlanner;

namespace WinFormsAppfinalhwk
{
    public partial class ExamForm : Form
    {
        private string userId;

        // 字段声明为可空，避免CS8618警告
        private TextBox? txtSubjectCustom;
        private ComboBox? cmbImportanceCustom;
        private TextBox? txtKeyTopicsCustom;
        private DateTimePicker? dtpExamDateCustom;
        private Button? btnAddExamCustom;
        private Button? btnDeleteExamCustom;
        private DataGridView? dgvExamsCustom;

        public ExamForm(string userId)
        {
            this.userId = userId;
            InitializeCustomComponent();

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

            // 统一字体和控件风格
            var commonFont = new Font("微软雅黑", 10F, FontStyle.Regular);
            this.Font = commonFont;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Font = commonFont;
                if (ctrl is Button btn)
                {
                    btn.Font = new Font("楷体", 11F, FontStyle.Bold);
                    btn.BackColor = Color.Gold;
                    btn.ForeColor = Color.Black;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 2;
                    btn.FlatAppearance.BorderColor = Color.Orange;
                }
                if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.DefaultCellStyle.Font = commonFont;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.EnableHeadersVisualStyles = false;
                }
            }

            EnsureExamTable();
            LoadExams();

            // 修复CS8652：不使用?.赋值，直接判空后赋值
            if (btnAddExamCustom != null)
                btnAddExamCustom.Click += btnAddExam_Click;
            if (btnDeleteExamCustom != null)
                btnDeleteExamCustom.Click += btnDeleteExam_Click;
        }

        /// <summary>
        /// 自定义控件初始化，全部用 Custom 后缀，避免与设计器控件冲突
        /// </summary>
        private void InitializeCustomComponent()
        {
            int margin = 20, spacing = 10, top = margin;
            int inputHeight = 30, btnHeight = 36;

            txtSubjectCustom = new TextBox { Location = new Point(margin, top), Width = 200, Height = inputHeight, Name = "txtSubjectCustom" };
            this.Controls.Add(txtSubjectCustom);

            cmbImportanceCustom = new ComboBox { Location = new Point(txtSubjectCustom.Right + spacing, top), Width = 100, Height = inputHeight, Name = "cmbImportanceCustom" };
            cmbImportanceCustom.Items.AddRange(new string[] { "高", "中", "低" });
            cmbImportanceCustom.SelectedIndex = 1;
            this.Controls.Add(cmbImportanceCustom);

            txtKeyTopicsCustom = new TextBox { Location = new Point(cmbImportanceCustom.Right + spacing, top), Width = 200, Height = inputHeight, Name = "txtKeyTopicsCustom" };
            this.Controls.Add(txtKeyTopicsCustom);

            dtpExamDateCustom = new DateTimePicker { Location = new Point(txtKeyTopicsCustom.Right + spacing, top), Width = 150, Height = inputHeight, Name = "dtpExamDateCustom", Format = DateTimePickerFormat.Custom, CustomFormat = "yyyy-MM-dd" };
            this.Controls.Add(dtpExamDateCustom);

            int btnWidth = 140;
            btnAddExamCustom = new Button
            {
                Location = new Point(dtpExamDateCustom.Right + spacing, top),
                Width = btnWidth,
                Height = btnHeight,
                Text = "添加考试",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Gold,
                ForeColor = Color.Black,
                Font = new Font("楷体", 11F, FontStyle.Bold)
            };
            btnAddExamCustom.FlatAppearance.BorderColor = Color.Orange;
            btnAddExamCustom.FlatAppearance.BorderSize = 2;
            this.Controls.Add(btnAddExamCustom);

            btnDeleteExamCustom = new Button
            {
                Location = new Point(btnAddExamCustom.Right + spacing, top),
                Width = btnWidth,
                Height = btnHeight,
                Text = "删除考试",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Gold,
                ForeColor = Color.Black,
                Font = new Font("楷体", 11F, FontStyle.Bold)
            };
            btnDeleteExamCustom.FlatAppearance.BorderColor = Color.Orange;
            btnDeleteExamCustom.FlatAppearance.BorderSize = 2;
            this.Controls.Add(btnDeleteExamCustom);

            dgvExamsCustom = new DataGridView
            {
                Location = new Point(margin, top + inputHeight + spacing),
                Size = new Size(910, 400),
                Name = "dgvExamsCustom",
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            this.Controls.Add(dgvExamsCustom);
        }

        /// <summary>
        /// 只补全普通字段，不自动添加主键，避免表结构异常
        /// </summary>
        private void EnsureExamTable()
        {
            string createSql = @"
                CREATE TABLE IF NOT EXISTS Exams (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    UserId VARCHAR(50) NOT NULL,
                    Subject VARCHAR(100) NOT NULL,
                    ExamDate DATETIME NOT NULL,
                    Importance VARCHAR(10) NOT NULL DEFAULT '中',
                    KeyTopics VARCHAR(255) DEFAULT '',
                    FOREIGN KEY (UserId) REFERENCES Users(UserId)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = $"SHOW TABLES LIKE 'Exams'";
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
                    else
                    {
                        // 只补全普通字段，不自动添加主键
                        string checkImportanceSql = "SHOW COLUMNS FROM Exams LIKE 'Importance'";
                        using (var checkCmd = new MySqlCommand(checkImportanceSql, conn))
                        {
                            var colResult = checkCmd.ExecuteScalar();
                            if (colResult == null)
                            {
                                string addImportanceSql = "ALTER TABLE Exams ADD COLUMN Importance VARCHAR(10) NOT NULL DEFAULT '中'";
                                using (var addCmd = new MySqlCommand(addImportanceSql, conn))
                                {
                                    addCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        string checkKeyTopicsSql = "SHOW COLUMNS FROM Exams LIKE 'KeyTopics'";
                        using (var checkCmd = new MySqlCommand(checkKeyTopicsSql, conn))
                        {
                            var colResult = checkCmd.ExecuteScalar();
                            if (colResult == null)
                            {
                                string addKeyTopicsSql = "ALTER TABLE Exams ADD COLUMN KeyTopics VARCHAR(255) DEFAULT ''";
                                using (var addCmd = new MySqlCommand(addKeyTopicsSql, conn))
                                {
                                    addCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoadExams()
        {
            // 修复CS8602：判空后操作
            if (dgvExamsCustom == null) return;
            dgvExamsCustom.Rows.Clear();
            dgvExamsCustom.Columns.Clear();
            dgvExamsCustom.Columns.Add("Id", "ID"); // 隐藏主键
            if (dgvExamsCustom.Columns["Id"] != null)
                dgvExamsCustom.Columns["Id"].Visible = false;
            dgvExamsCustom.Columns.Add("Subject", "考试科目");
            dgvExamsCustom.Columns.Add("ExamDate", "考试日期");
            dgvExamsCustom.Columns.Add("Importance", "重要性");
            dgvExamsCustom.Columns.Add("KeyTopics", "重点内容");
            dgvExamsCustom.Columns.Add("Countdown", "倒计时(天)");

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Id, Subject, ExamDate, Importance, KeyTopics FROM exams WHERE UserId=@UserId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime examDate = reader["ExamDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["ExamDate"]);
                            int days = (examDate.Date - DateTime.Now.Date).Days;
                            int rowIndex = dgvExamsCustom.Rows.Add(
                                reader["Id"]?.ToString() ?? "",
                                reader["Subject"]?.ToString() ?? "",
                                examDate.ToString("yyyy-MM-dd"),
                                reader["Importance"]?.ToString() ?? "中",
                                reader["KeyTopics"]?.ToString() ?? "",
                                days
                            );
                            if (days < 3 && days >= 0)
                            {
                                dgvExamsCustom.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                                dgvExamsCustom.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;
                                dgvExamsCustom.Rows[rowIndex].DefaultCellStyle.Font = new Font(dgvExamsCustom.Font, FontStyle.Bold);
                            }
                            if (days < 0)
                            {
                                dgvExamsCustom.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                                dgvExamsCustom.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
                                dgvExamsCustom.Rows[rowIndex].DefaultCellStyle.Font = new Font(dgvExamsCustom.Font, FontStyle.Italic);
                            }
                        }
                    }
                }
            }
        }

        private void btnAddExam_Click(object? sender, EventArgs e)
        {
            EnsureExamTable();
            string subject = txtSubjectCustom?.Text.Trim() ?? "";
            string importance = cmbImportanceCustom?.Text.Trim() ?? "";
            string keyTopics = txtKeyTopicsCustom?.Text.Trim() ?? "";
            DateTime examDate = dtpExamDateCustom?.Value ?? DateTime.Now;

            if (string.IsNullOrWhiteSpace(subject))
            {
                MessageBox.Show("请填写考试科目！");
                return;
            }

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM Exams WHERE UserId=@UserId AND Subject=@Subject AND ExamDate=@ExamDate";
                using (var cmd = new MySqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@ExamDate", examDate);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertSql = "INSERT INTO Exams (UserId, Subject, ExamDate, Importance, KeyTopics) VALUES (@UserId, @Subject, @ExamDate, @Importance, @KeyTopics)";
                        using (var insertCmd = new MySqlCommand(insertSql, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@UserId", userId);
                            insertCmd.Parameters.AddWithValue("@Subject", subject);
                            insertCmd.Parameters.AddWithValue("@ExamDate", examDate);
                            insertCmd.Parameters.AddWithValue("@Importance", string.IsNullOrEmpty(importance) ? "中" : importance);
                            insertCmd.Parameters.AddWithValue("@KeyTopics", keyTopics);
                            insertCmd.ExecuteNonQuery();
                        }
                        LoadExams();
                    }
                    else
                    {
                        MessageBox.Show("该考试已存在！");
                    }
                }
            }
        }

        private void btnDeleteExam_Click(object? sender, EventArgs e)
        {
            if (dgvExamsCustom == null || dgvExamsCustom.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的考试。");
                return;
            }
            var selectedRow = dgvExamsCustom.SelectedRows[0];
            string idStr = selectedRow.Cells["Id"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(idStr))
            {
                MessageBox.Show("无法获取考试ID。");
                return;
            }
            int id = int.Parse(idStr);

            var result = MessageBox.Show("确定要删除选中的考试吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM exams WHERE Id=@Id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadExams();
        }

        private void btnAddExam_Click_1(object sender, EventArgs e)
        {
            EnsureExamTable();
            string subject = txtSubjectCustom?.Text.Trim() ?? "";
            string importance = cmbImportanceCustom?.Text.Trim() ?? "";
            string keyTopics = txtKeyTopicsCustom?.Text.Trim() ?? "";
            DateTime examDate = dtpExamDateCustom?.Value ?? DateTime.Now;
            if (string.IsNullOrWhiteSpace(subject))
            {
                MessageBox.Show("请填写考试科目！");
                return;
            }
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string checkSql = "SELECT COUNT(*) FROM Exams WHERE UserId=@UserId AND Subject=@Subject AND ExamDate=@ExamDate";
                using (var cmd = new MySqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@ExamDate", examDate);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertSql = "INSERT INTO Exams (UserId, Subject, ExamDate, Importance, KeyTopics) VALUES (@UserId, @Subject, @ExamDate, @Importance, @KeyTopics)";
                        using (var insertCmd = new MySqlCommand(insertSql, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@UserId", userId);
                            insertCmd.Parameters.AddWithValue("@Subject", subject);
                            insertCmd.Parameters.AddWithValue("@ExamDate", examDate);
                            insertCmd.Parameters.AddWithValue("@Importance", string.IsNullOrEmpty(importance) ? "中" : importance);
                            insertCmd.Parameters.AddWithValue("@KeyTopics", keyTopics);
                            insertCmd.ExecuteNonQuery();
                        }
                        LoadExams();
                    }
                    else
                    {
                        MessageBox.Show("该考试已存在！");
                    }
                }
            }
        }
    }
}
