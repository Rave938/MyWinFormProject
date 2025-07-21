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
    public partial class NoteForm : Form
    {
        private string userId;
        // 在 NoteForm 类中添加一个字段用于记录当前选中的标题
        private string? selectedTitle = null;

        public NoteForm(string userId)
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

            // 不要 new rtbNote，这会覆盖 Designer 生成的控件
            // rtbNote = new RichTextBox();
            // rtbNote.Font = new Font("楷体", 13F);
            // rtbNote.Location = new Point(650, 80);
            // rtbNote.Size = new Size(350, 200);

            EnsureNoteTable();
            LoadTags();
            LoadNotes();

            btnSearch.Click += BtnSearch_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void EnsureNoteTable()
        {
            string createSql = @"
                CREATE TABLE IF NOT EXISTS Notes (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    UserId VARCHAR(50),
                    Title VARCHAR(100),
                    Content TEXT,
                    Tag VARCHAR(50),
                    CreateTime DATETIME
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (var createCmd = new MySqlCommand(createSql, conn))
                {
                    createCmd.ExecuteNonQuery();
                }
            }
        }

        // 加载所有标签到下拉框
        private void LoadTags()
        {
            cbTag.Items.Clear();
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT DISTINCT Tag FROM Notes WHERE UserId=@UserId AND Tag IS NOT NULL AND Tag<>''";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbTag.Items.Add(reader["Tag"].ToString());
                        }
                    }
                }
            }
        }

        private void LoadNotes(string keyword = "")
        {
            dgvNotes.Rows.Clear();
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Title, Tag, CreateTime, Content FROM Notes WHERE UserId=@UserId";
                if (!string.IsNullOrWhiteSpace(keyword))
                    sql += " AND (Title LIKE @Key OR Content LIKE @Key)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    if (!string.IsNullOrWhiteSpace(keyword))
                        cmd.Parameters.AddWithValue("@Key", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string content = reader["Content"]?.ToString() ?? "";
                            dgvNotes.Rows.Add(
                                reader["Title"]?.ToString() ?? "",
                                reader["Tag"]?.ToString() ?? "",
                                reader["CreateTime"] is DBNull ? "" : Convert.ToDateTime(reader["CreateTime"]).ToString("yyyy-MM-dd HH:mm"),
                                content
                            );
                        }
                    }
                }
            }
            rtbNote.Clear();
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadNotes(txtSearch.Text.Trim());
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            string title = Microsoft.VisualBasic.Interaction.InputBox("笔记标题：", "保存笔记", selectedTitle ?? "");
            if (string.IsNullOrWhiteSpace(title)) return;
            string content = rtbNote.Text;
            string tag = cbTag.Text;
            DateTime createTime = DateTime.Now;

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                if (selectedTitle != null && selectedTitle == title)
                {
                    // 修改已存在的笔记
                    string updateSql = "UPDATE Notes SET Content=@Content, Tag=@Tag WHERE UserId=@UserId AND Title=@Title";
                    using (var updateCmd = new MySqlCommand(updateSql, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@UserId", userId);
                        updateCmd.Parameters.AddWithValue("@Title", title);
                        updateCmd.Parameters.AddWithValue("@Content", content);
                        updateCmd.Parameters.AddWithValue("@Tag", tag);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // 新建笔记或标题已更改
                    string checkSql = "SELECT COUNT(*) FROM Notes WHERE UserId=@UserId AND Title=@Title";
                    using (var cmd = new MySqlCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Title", title);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string insertSql = "INSERT INTO Notes (UserId, Title, Content, Tag, CreateTime) VALUES (@UserId, @Title, @Content, @Tag, @CreateTime)";
                            using (var insertCmd = new MySqlCommand(insertSql, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@UserId", userId);
                                insertCmd.Parameters.AddWithValue("@Title", title);
                                insertCmd.Parameters.AddWithValue("@Content", content);
                                insertCmd.Parameters.AddWithValue("@Tag", tag);
                                insertCmd.Parameters.AddWithValue("@CreateTime", createTime);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show("该标题的笔记已存在！");
                        }
                    }
                }
                LoadTags();
                LoadNotes();
                selectedTitle = null; // 保存后清空选中
            }
        }

        private void DgvNotes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            selectedTitle = dgvNotes.Rows[e.RowIndex].Cells["Title"].Value?.ToString() ?? "";
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT Content, Tag FROM Notes WHERE UserId=@UserId AND Title=@Title";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@Title", selectedTitle);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rtbNote.Text = reader["Content"]?.ToString() ?? "";
                            string tag = reader["Tag"]?.ToString() ?? "";
                            cbTag.SelectedItem = tag;
                        }
                    }
                }
            }
        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void NoteForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
