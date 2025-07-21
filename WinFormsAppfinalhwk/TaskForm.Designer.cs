using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class TaskForm
    {
        private DataGridView dgvTasks;
        private RoundButton btnAddTask;
        private RoundButton btnMarkToday;
        private RoundButton btnBatchComplete;
        private Label labelTitle;

        // 新增控件
        private TextBox txtTaskName;
        private TextBox txtCourseName;
        private DateTimePicker dtpDeadline;
        private ComboBox cbPriority;
        private CheckBox chkIsCompleted;
        private Label lblTaskName;
        private Label lblTaskCourse;
        private Label lblDeadline;
        private Label lblPriority;
        private Label lblIsCompleted;

        private void InitializeComponent()
        {
            dgvTasks = new DataGridView();
            btnAddTask = new RoundButton();
            btnMarkToday = new RoundButton();
            btnBatchComplete = new RoundButton();
            labelTitle = new Label();
            txtTaskName = new TextBox();
            txtCourseName = new TextBox();
            dtpDeadline = new DateTimePicker();
            cbPriority = new ComboBox();
            chkIsCompleted = new CheckBox();
            lblTaskName = new Label();
            lblTaskCourse = new Label();
            lblDeadline = new Label();
            lblPriority = new Label();
            lblIsCompleted = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // dgvTasks
            // 
            dgvTasks.BackgroundColor = Color.White;
            dgvTasks.ColumnHeadersHeight = 34;
            dgvTasks.Font = new Font("楷体", 13F);
            dgvTasks.Location = new Point(30, 80);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 62;
            dgvTasks.Size = new Size(1178, 535);
            dgvTasks.TabIndex = 1;
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.Gold;
            btnAddTask.FlatAppearance.BorderSize = 0;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnAddTask.ForeColor = Color.LightCoral;
            btnAddTask.Location = new Point(1272, 80);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(138, 44);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "添加任务";
            btnAddTask.UseVisualStyleBackColor = false;
            // 
            // btnMarkToday
            // 
            btnMarkToday.BackColor = Color.Gold;
            btnMarkToday.FlatAppearance.BorderSize = 0;
            btnMarkToday.FlatStyle = FlatStyle.Flat;
            btnMarkToday.Font = new Font("楷体", 8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnMarkToday.ForeColor = Color.LightCoral;
            btnMarkToday.Location = new Point(1272, 140);
            btnMarkToday.Name = "btnMarkToday";
            btnMarkToday.Size = new Size(138, 44);
            btnMarkToday.TabIndex = 3;
            btnMarkToday.Text = "标记今日完成";
            btnMarkToday.UseVisualStyleBackColor = false;
            // 
            // btnBatchComplete
            // 
            btnBatchComplete.BackColor = Color.Gold;
            btnBatchComplete.FlatAppearance.BorderSize = 0;
            btnBatchComplete.FlatStyle = FlatStyle.Flat;
            btnBatchComplete.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnBatchComplete.ForeColor = Color.LightCoral;
            btnBatchComplete.Location = new Point(1272, 140);
            btnBatchComplete.Name = "btnBatchComplete";
            btnBatchComplete.Size = new Size(138, 44);
            btnBatchComplete.TabIndex = 4;
            btnBatchComplete.Text = "批量完成";
            btnBatchComplete.UseVisualStyleBackColor = false;
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
            labelTitle.Text = "任务管理";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(0, 0);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(100, 30);
            txtTaskName.TabIndex = 0;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(0, 0);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(100, 30);
            txtCourseName.TabIndex = 0;
            // 
            // dtpDeadline
            // 
            dtpDeadline.Location = new Point(0, 0);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(200, 30);
            dtpDeadline.TabIndex = 0;
            // 
            // cbPriority
            // 
            cbPriority.Items.AddRange(new object[] { "高", "中", "低" });
            cbPriority.Location = new Point(0, 0);
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new Size(121, 32);
            cbPriority.TabIndex = 0;
            // 
            // chkIsCompleted
            // 
            chkIsCompleted.Location = new Point(0, 0);
            chkIsCompleted.Name = "chkIsCompleted";
            chkIsCompleted.Size = new Size(104, 24);
            chkIsCompleted.TabIndex = 0;
            // 
            // lblTaskName
            // 
            lblTaskName.Location = new Point(0, 0);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(100, 23);
            lblTaskName.TabIndex = 0;
            // 
            // lblTaskCourse
            // 
            lblTaskCourse.Location = new Point(0, 0);
            lblTaskCourse.Name = "lblTaskCourse";
            lblTaskCourse.Size = new Size(100, 23);
            lblTaskCourse.TabIndex = 0;
            // 
            // lblDeadline
            // 
            lblDeadline.Location = new Point(0, 0);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(100, 23);
            lblDeadline.TabIndex = 0;
            // 
            // lblPriority
            // 
            lblPriority.Location = new Point(0, 0);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(100, 23);
            lblPriority.TabIndex = 0;
            // 
            // lblIsCompleted
            // 
            lblIsCompleted.Location = new Point(0, 0);
            lblIsCompleted.Name = "lblIsCompleted";
            lblIsCompleted.Size = new Size(100, 23);
            lblIsCompleted.TabIndex = 0;
            // 
            // TaskForm
            // 
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1745, 750);
            Controls.Add(labelTitle);
            Controls.Add(dgvTasks);
            Controls.Add(btnAddTask);
            Controls.Add(btnBatchComplete);
            Controls.Add(btnMarkToday);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TaskForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "任务管理";
            Load += TaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}