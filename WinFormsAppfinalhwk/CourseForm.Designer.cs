using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class CourseForm
    {
        private DataGridView dgvCourses;
        private RoundButton btnAddCourse;
        private RoundButton btnImport;
        private RoundButton btnDeleteCourse;
        private Label labelTitle;
        private TextBox txtCourseName;
        private NumericUpDown nudCredit;
        private TextBox txtClassTime;
        private ComboBox cbDifficulty;
        private Label lblCourseName;
        private Label lblCredit;
        private Label lblClassTime;
        private Label lblDifficulty;

        private void InitializeComponent()
        {
            dgvCourses = new DataGridView();
            btnAddCourse = new RoundButton();
            btnImport = new RoundButton();
            btnDeleteCourse = new RoundButton();
            labelTitle = new Label();
            txtCourseName = new TextBox();
            nudCredit = new NumericUpDown();
            txtClassTime = new TextBox();
            cbDifficulty = new ComboBox();
            lblCourseName = new Label();
            lblCredit = new Label();
            lblClassTime = new Label();
            lblDifficulty = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCredit).BeginInit();
            SuspendLayout();
            // 
            // dgvCourses
            // 
            dgvCourses.BackgroundColor = Color.White;
            dgvCourses.ColumnHeadersHeight = 34;
            dgvCourses.Font = new Font("楷体", 13F);
            dgvCourses.Location = new Point(30, 80);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersWidth = 62;
            dgvCourses.Size = new Size(1026, 300);
            dgvCourses.TabIndex = 1;
            // 
            // btnAddCourse
            // 
            btnAddCourse.BackColor = Color.Gold;
            btnAddCourse.FlatAppearance.BorderSize = 0;
            btnAddCourse.FlatStyle = FlatStyle.Flat;
            btnAddCourse.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnAddCourse.ForeColor = Color.LightCoral;
            btnAddCourse.Location = new Point(1076, 250);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(142, 44);
            btnAddCourse.TabIndex = 2;
            btnAddCourse.Text = "添加课程";
            btnAddCourse.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.Gold;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnImport.ForeColor = Color.LightCoral;
            btnImport.Location = new Point(1076, 310);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(142, 44);
            btnImport.TabIndex = 3;
            btnImport.Text = "导入课表";
            btnImport.UseVisualStyleBackColor = false;
            // 
            // btnDeleteCourse
            // 
            btnDeleteCourse.BackColor = Color.Gold;
            btnDeleteCourse.FlatAppearance.BorderSize = 0;
            btnDeleteCourse.FlatStyle = FlatStyle.Flat;
            btnDeleteCourse.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnDeleteCourse.ForeColor = Color.LightCoral;
            btnDeleteCourse.Location = new Point(1076, 310);
            btnDeleteCourse.Name = "btnDeleteCourse";
            btnDeleteCourse.Size = new Size(142, 44);
            btnDeleteCourse.TabIndex = 4;
            btnDeleteCourse.Text = "删除课程";
            btnDeleteCourse.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("楷体", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.IndianRed;
            labelTitle.Location = new Point(320, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(163, 36);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "课程管理";
            // 
            // txtCourseName
            // 
            txtCourseName.Font = new Font("楷体", 13F);
            txtCourseName.Location = new Point(1228, 80);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(120, 37);
            txtCourseName.TabIndex = 5;
            // 
            // nudCredit
            // 
            nudCredit.Font = new Font("楷体", 13F);
            nudCredit.Location = new Point(1228, 120);
            nudCredit.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudCredit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCredit.Name = "nudCredit";
            nudCredit.Size = new Size(120, 37);
            nudCredit.TabIndex = 6;
            nudCredit.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // txtClassTime
            // 
            txtClassTime.Font = new Font("楷体", 13F);
            txtClassTime.Location = new Point(1228, 160);
            txtClassTime.Name = "txtClassTime";
            txtClassTime.Size = new Size(353, 37);
            txtClassTime.TabIndex = 7;
            // 
            // cbDifficulty
            // 
            cbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDifficulty.Font = new Font("楷体", 13F);
            cbDifficulty.Items.AddRange(new object[] { "简单", "中等", "困难" });
            cbDifficulty.Location = new Point(1228, 200);
            cbDifficulty.Name = "cbDifficulty";
            cbDifficulty.Size = new Size(120, 34);
            cbDifficulty.TabIndex = 8;
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.BackColor = Color.Transparent;
            lblCourseName.Font = new Font("楷体", 12F);
            lblCourseName.Location = new Point(1076, 80);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(82, 24);
            lblCourseName.TabIndex = 9;
            lblCourseName.Text = "课程名";
            // 
            // lblCredit
            // 
            lblCredit.AutoSize = true;
            lblCredit.BackColor = Color.Transparent;
            lblCredit.Font = new Font("楷体", 12F);
            lblCredit.Location = new Point(1076, 120);
            lblCredit.Name = "lblCredit";
            lblCredit.Size = new Size(58, 24);
            lblCredit.TabIndex = 10;
            lblCredit.Text = "学分";
            // 
            // lblClassTime
            // 
            lblClassTime.AutoSize = true;
            lblClassTime.BackColor = Color.Transparent;
            lblClassTime.Font = new Font("楷体", 12F);
            lblClassTime.Location = new Point(1076, 160);
            lblClassTime.Name = "lblClassTime";
            lblClassTime.Size = new Size(106, 24);
            lblClassTime.TabIndex = 11;
            lblClassTime.Text = "上课时间";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.BackColor = Color.Transparent;
            lblDifficulty.Font = new Font("楷体", 12F);
            lblDifficulty.Location = new Point(1076, 200);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(58, 24);
            lblDifficulty.TabIndex = 12;
            lblDifficulty.Text = "难度";
            lblDifficulty.Click += lblDifficulty_Click;
            // 
            // CourseForm
            // 
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1615, 898);
            Controls.Add(labelTitle);
            Controls.Add(dgvCourses);
            Controls.Add(btnAddCourse);
            Controls.Add(btnDeleteCourse);
            Controls.Add(txtCourseName);
            Controls.Add(nudCredit);
            Controls.Add(txtClassTime);
            Controls.Add(cbDifficulty);
            Controls.Add(lblCourseName);
            Controls.Add(lblCredit);
            Controls.Add(lblClassTime);
            Controls.Add(lblDifficulty);
            Controls.Add(btnImport);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CourseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "课程管理";
            Load += CourseForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCredit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}