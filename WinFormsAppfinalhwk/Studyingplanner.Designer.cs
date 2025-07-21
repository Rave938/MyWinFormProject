using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class StudyingPlanner
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            dgvStudyPlan = new DataGridView();
            TimeSlotColumn = new DataGridViewTextBoxColumn();
            SubjectColumn = new DataGridViewTextBoxColumn();
            TaskColumn = new DataGridViewTextBoxColumn();
            DurationColumn = new DataGridViewTextBoxColumn();
            PriorityColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            txtSummary = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnRefreshPlan = new RoundButton(); // 修改类型
            btnSavePlan = new RoundButton();    // 修改类型
            ((System.ComponentModel.ISupportInitialize)dgvStudyPlan).BeginInit();
            SuspendLayout();
            // 
            // dgvStudyPlan
            // 
            dgvStudyPlan.AllowUserToAddRows = false;
            dgvStudyPlan.AllowUserToDeleteRows = false;
            dgvStudyPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudyPlan.Columns.AddRange(new DataGridViewColumn[] { TimeSlotColumn, SubjectColumn, TaskColumn, DurationColumn, PriorityColumn, DescriptionColumn });
            dgvStudyPlan.Location = new Point(16, 46);
            dgvStudyPlan.Margin = new Padding(4, 4, 4, 4);
            dgvStudyPlan.Name = "dgvStudyPlan";
            dgvStudyPlan.ReadOnly = true;
            dgvStudyPlan.RowHeadersWidth = 51;
            dgvStudyPlan.RowTemplate.Height = 29;
            dgvStudyPlan.Size = new Size(1304, 420);
            dgvStudyPlan.TabIndex = 0;
            // 
            // TimeSlotColumn
            // 
            TimeSlotColumn.MinimumWidth = 8;
            TimeSlotColumn.Name = "TimeSlotColumn";
            TimeSlotColumn.ReadOnly = true;
            TimeSlotColumn.Width = 120;
            // 
            // SubjectColumn
            // 
            SubjectColumn.MinimumWidth = 8;
            SubjectColumn.Name = "SubjectColumn";
            SubjectColumn.ReadOnly = true;
            SubjectColumn.Width = 120;
            // 
            // TaskColumn
            // 
            TaskColumn.MinimumWidth = 8;
            TaskColumn.Name = "TaskColumn";
            TaskColumn.ReadOnly = true;
            TaskColumn.Width = 150;
            // 
            // DurationColumn
            // 
            DurationColumn.MinimumWidth = 8;
            DurationColumn.Name = "DurationColumn";
            DurationColumn.ReadOnly = true;
            // 
            // PriorityColumn
            // 
            PriorityColumn.MinimumWidth = 8;
            PriorityColumn.Name = "PriorityColumn";
            PriorityColumn.ReadOnly = true;
            PriorityColumn.Width = 80;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.MinimumWidth = 8;
            DescriptionColumn.Name = "DescriptionColumn";
            DescriptionColumn.ReadOnly = true;
            DescriptionColumn.Width = 250;
            // 
            // txtSummary
            // 
            txtSummary.Location = new Point(16, 509);
            txtSummary.Margin = new Padding(4, 4, 4, 4);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.ReadOnly = true;
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtSummary.Size = new Size(1302, 143);
            txtSummary.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(16, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(151, 30);
            label1.TabIndex = 2;
            label1.Text = "今日学习计划";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(16, 478);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 30);
            label2.TabIndex = 3;
            label2.Text = "计划摘要";
            // 
            // btnRefreshPlan
            // 
            btnRefreshPlan.Location = new Point(983, 660);
            btnRefreshPlan.Margin = new Padding(4, 4, 4, 4);
            btnRefreshPlan.Name = "btnRefreshPlan";
            btnRefreshPlan.Size = new Size(140, 49);
            btnRefreshPlan.TabIndex = 4;
            btnRefreshPlan.Text = "刷新计划";
            btnRefreshPlan.UseVisualStyleBackColor = false;
            btnRefreshPlan.BackColor = Color.Gold;
            btnRefreshPlan.FlatAppearance.BorderSize = 0;
            btnRefreshPlan.FlatStyle = FlatStyle.Flat;
            btnRefreshPlan.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnRefreshPlan.ForeColor = Color.LightCoral;
            btnRefreshPlan.Click += btnRefreshPlan_Click;
            // 
            // btnSavePlan
            // 
            btnSavePlan.Location = new Point(1149, 660);
            btnSavePlan.Margin = new Padding(4, 4, 4, 4);
            btnSavePlan.Name = "btnSavePlan";
            btnSavePlan.Size = new Size(140, 49);
            btnSavePlan.TabIndex = 5;
            btnSavePlan.Text = "保存计划";
            btnSavePlan.UseVisualStyleBackColor = false;
            btnSavePlan.BackColor = Color.Gold;
            btnSavePlan.FlatAppearance.BorderSize = 0;
            btnSavePlan.FlatStyle = FlatStyle.Flat;
            btnSavePlan.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnSavePlan.ForeColor = Color.LightCoral;
            btnSavePlan.Click += btnSavePlan_Click;
            // 
            // StudyingPlanner
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1336, 709);
            Controls.Add(btnSavePlan);
            Controls.Add(btnRefreshPlan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSummary);
            Controls.Add(dgvStudyPlan);
            Margin = new Padding(4, 4, 4, 4);
            Name = "StudyingPlanner";
            Text = "学习计划助手";
            ((System.ComponentModel.ISupportInitialize)dgvStudyPlan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudyPlan;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RoundButton btnRefreshPlan;
        private RoundButton btnSavePlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSlotColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DurationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriorityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
    }
}
