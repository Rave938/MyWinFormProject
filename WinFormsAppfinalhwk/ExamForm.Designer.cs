using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class ExamForm
    {
        private DataGridView dgvExams;
        private RoundButton btnAddExam;
        private RoundButton btnDeleteExam;
        private Label labelTitle;

        // 新增控件
        private TextBox txtExamName;
        private TextBox txtCourseName;
        private DateTimePicker dtpExamDate;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvExams = new DataGridView();
            btnAddExam = new RoundButton();
            btnDeleteExam = new RoundButton();
            labelTitle = new Label();
            txtExamName = new TextBox();
            txtCourseName = new TextBox();
            dtpExamDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvExams).BeginInit();
            SuspendLayout();
            // 
            // dgvExams
            // 
            dgvExams.BackgroundColor = Color.White;
            dgvExams.ColumnHeadersHeight = 34;
            dgvExams.Font = new Font("楷体", 13F);
            dgvExams.Location = new Point(35, 160);
            dgvExams.Name = "dgvExams";
            dgvExams.RowHeadersWidth = 62;
            dgvExams.Size = new Size(1011, 300);
            dgvExams.TabIndex = 1;
            // 
            // btnAddExam
            // 
            btnAddExam.AutoSize = true;
            btnAddExam.BackColor = Color.Gold;
            btnAddExam.FlatAppearance.BorderSize = 0;
            btnAddExam.FlatStyle = FlatStyle.Flat;
            btnAddExam.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnAddExam.ForeColor = Color.LightCoral;
            btnAddExam.Location = new Point(655, 86);
            btnAddExam.Name = "btnAddExam";
            btnAddExam.Size = new Size(171, 68);
            btnAddExam.TabIndex = 2;
            btnAddExam.Text = "添加考试";
            btnAddExam.UseVisualStyleBackColor = false;
            btnAddExam.Click += btnAddExam_Click_1;
            // 
            // btnDeleteExam
            // 
            btnDeleteExam.AutoSize = true;
            btnDeleteExam.BackColor = Color.Gold;
            btnDeleteExam.FlatAppearance.BorderSize = 0;
            btnDeleteExam.FlatStyle = FlatStyle.Flat;
            btnDeleteExam.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnDeleteExam.ForeColor = Color.LightCoral;
            btnDeleteExam.Location = new Point(832, 86);
            btnDeleteExam.Name = "btnDeleteExam";
            btnDeleteExam.Size = new Size(174, 68);
            btnDeleteExam.TabIndex = 3;
            btnDeleteExam.Text = "删除考试";
            btnDeleteExam.UseVisualStyleBackColor = false;
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
            labelTitle.Text = "考试管理";
            // 
            // txtExamName
            // 
            txtExamName.Location = new Point(1140, 199);
            txtExamName.Name = "txtExamName";
            txtExamName.Size = new Size(100, 30);
            txtExamName.TabIndex = 4;
            txtExamName.TextChanged += txtExamName_TextChanged;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(1140, 238);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(100, 30);
            txtCourseName.TabIndex = 5;
            txtCourseName.TextChanged += txtCourseName_TextChanged;
            // 
            // dtpExamDate
            // 
            dtpExamDate.Location = new Point(1052, 160);
            dtpExamDate.Name = "dtpExamDate";
            dtpExamDate.Size = new Size(200, 30);
            dtpExamDate.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("楷体", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(1050, 206);
            label1.Name = "label1";
            label1.Size = new Size(84, 18);
            label1.TabIndex = 10;
            label1.Text = "考试科目";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("楷体", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(1052, 245);
            label2.Name = "label2";
            label2.Size = new Size(84, 18);
            label2.TabIndex = 11;
            label2.Text = "关联科目";
            // 
            // ExamForm
            // 
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1480, 750);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelTitle);
            Controls.Add(dgvExams);
            Controls.Add(btnAddExam);
            Controls.Add(btnDeleteExam);
            Controls.Add(txtExamName);
            Controls.Add(txtCourseName);
            Controls.Add(dtpExamDate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ExamForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "考试管理";
            Load += ExamForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvExams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;

        // 在 partial class ExamForm 内部添加如下空方法实现
        private void txtExamName_TextChanged(object sender, EventArgs e)
        {
            // 可根据需要添加逻辑，暂为空实现
        }

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {
            // 可根据需要添加逻辑，暂为空实现
        }

        private void ExamForm_Load_1(object sender, EventArgs e)
        {
            // 可根据需要添加逻辑，暂为空实现
        }
    }
}