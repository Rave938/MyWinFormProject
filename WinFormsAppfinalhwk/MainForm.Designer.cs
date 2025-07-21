using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class MainForm
    {
        private System.Windows.Forms.Timer timer1; // 明确指定类型
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuCourse;
        private ToolStripMenuItem menuTask;
        private ToolStripMenuItem menuExam;
        private ToolStripMenuItem menuNote;
        private RoundButton btnTodayTask;
        private RoundButton btnUpcomingExam;
        private Label lblUser;
        private Label lblTime;
        private Label lblStudyTime;
        private RoundButton btnLogout;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip = new MenuStrip();
            menuCourse = new ToolStripMenuItem();
            menuTask = new ToolStripMenuItem();
            menuExam = new ToolStripMenuItem();
            menuNote = new ToolStripMenuItem();
            btnTodayTask = new RoundButton();
            btnUpcomingExam = new RoundButton();
            lblUser = new Label();
            lblTime = new Label();
            lblStudyTime = new Label();
            btnLogout = new RoundButton();
            btnStudyPlanner = new RoundButton();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(230, 240, 255);
            menuStrip.Font = new Font("楷体", 13F, FontStyle.Bold);
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuCourse, menuTask, menuExam, menuNote });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1423, 34);
            menuStrip.TabIndex = 0;
            // 
            // menuCourse
            // 
            menuCourse.Name = "menuCourse";
            menuCourse.Size = new Size(136, 30);
            menuCourse.Text = "课程管理";
            menuCourse.Click += menuCourse_Click;
            // 
            // menuTask
            // 
            menuTask.Name = "menuTask";
            menuTask.Size = new Size(136, 30);
            menuTask.Text = "任务管理";
            menuTask.Click += menuTask_Click;
            // 
            // menuExam
            // 
            menuExam.Name = "menuExam";
            menuExam.Size = new Size(136, 30);
            menuExam.Text = "考试管理";
            menuExam.Click += menuExam_Click;
            // 
            // menuNote
            // 
            menuNote.Name = "menuNote";
            menuNote.Size = new Size(136, 30);
            menuNote.Text = "笔记管理";
            menuNote.Click += menuNote_Click;
            // 
            // btnTodayTask
            // 
            btnTodayTask.BackColor = Color.Gold;
            btnTodayTask.FlatAppearance.BorderSize = 0;
            btnTodayTask.FlatStyle = FlatStyle.Flat;
            btnTodayTask.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnTodayTask.ForeColor = Color.LightCoral;
            btnTodayTask.Location = new Point(60, 80);
            btnTodayTask.Name = "btnTodayTask";
            btnTodayTask.Size = new Size(180, 60);
            btnTodayTask.TabIndex = 1;
            btnTodayTask.Text = "今日待办";
            btnTodayTask.UseVisualStyleBackColor = false;
            // 
            // btnUpcomingExam
            // 
            btnUpcomingExam.BackColor = Color.Gold;
            btnUpcomingExam.FlatAppearance.BorderSize = 0;
            btnUpcomingExam.FlatStyle = FlatStyle.Flat;
            btnUpcomingExam.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnUpcomingExam.ForeColor = Color.LightCoral;
            btnUpcomingExam.Location = new Point(260, 80);
            btnUpcomingExam.Name = "btnUpcomingExam";
            btnUpcomingExam.Size = new Size(180, 60);
            btnUpcomingExam.TabIndex = 2;
            btnUpcomingExam.Text = "最近考试";
            btnUpcomingExam.UseVisualStyleBackColor = false;
            btnUpcomingExam.Click += btnUpcomingExam_Click_1;
            // 
            // lblUser
            // 
            lblUser.BackColor = Color.Transparent;
            lblUser.Font = new Font("楷体", 13F, FontStyle.Bold);
            lblUser.ForeColor = Color.IndianRed;
            lblUser.Location = new Point(60, 160);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(482, 40);
            lblUser.TabIndex = 3;
            lblUser.Text = "当前用户：";
            // 
            // lblTime
            // 
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = new Font("楷体", 13F, FontStyle.Bold);
            lblTime.ForeColor = Color.FromArgb(255, 128, 0);
            lblTime.Location = new Point(60, 200);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(342, 23);
            lblTime.TabIndex = 4;
            lblTime.Text = "系统时间：";
            // 
            // lblStudyTime
            // 
            lblStudyTime.BackColor = Color.Transparent;
            lblStudyTime.Font = new Font("楷体", 13F, FontStyle.Bold);
            lblStudyTime.ForeColor = Color.FromArgb(255, 128, 0);
            lblStudyTime.Location = new Point(60, 240);
            lblStudyTime.Name = "lblStudyTime";
            lblStudyTime.Size = new Size(291, 23);
            lblStudyTime.TabIndex = 5;
            lblStudyTime.Text = "学习时长：";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.BackColor = Color.Gold;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("楷体", 12F, FontStyle.Bold);
            btnLogout.ForeColor = Color.LightCoral;
            btnLogout.Location = new Point(1183, 679);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(228, 44);
            btnLogout.TabIndex = 99;
            btnLogout.Text = "退出/切换账号";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnStudyPlanner
            // 
            btnStudyPlanner.BackColor = Color.Gold;
            btnStudyPlanner.FlatAppearance.BorderSize = 0;
            btnStudyPlanner.FlatStyle = FlatStyle.Flat;
            btnStudyPlanner.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnStudyPlanner.ForeColor = Color.LightCoral;
            btnStudyPlanner.Location = new Point(456, 80);
            btnStudyPlanner.Name = "btnStudyPlanner";
            btnStudyPlanner.Size = new Size(177, 60);
            btnStudyPlanner.TabIndex = 8;
            btnStudyPlanner.Text = "学习计划";
            btnStudyPlanner.UseVisualStyleBackColor = false;
            btnStudyPlanner.Click += btnStudyPlanner_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1423, 747);
            Controls.Add(btnStudyPlanner);
            Controls.Add(menuStrip);
            Controls.Add(btnUpcomingExam);
            Controls.Add(btnTodayTask);
            Controls.Add(lblUser);
            Controls.Add(lblTime);
            Controls.Add(lblStudyTime);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学习计划总控制台";
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.ComponentModel.IContainer components;
        private RoundButton btnStudyPlanner;
    }
}