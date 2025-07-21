using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class GroupForm
    {
        private ListView lvGroups;
        private FlowLayoutPanel flpPunchWall;
        private RoundButton btnCreateGroupTask;
        private Label labelTitle;

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
            lvGroups = new ListView();
            flpPunchWall = new FlowLayoutPanel();
            btnCreateGroupTask = new RoundButton();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // lvGroups
            // 
            lvGroups.BackColor = Color.White;
            lvGroups.Font = new Font("楷体", 13F);
            lvGroups.Location = new Point(30, 80);
            lvGroups.Name = "lvGroups";
            lvGroups.Size = new Size(486, 300);
            lvGroups.TabIndex = 0;
            lvGroups.UseCompatibleStateImageBehavior = false;
            // 
            // flpPunchWall
            // 
            flpPunchWall.BackColor = Color.Transparent;
            flpPunchWall.Location = new Point(540, 80);
            flpPunchWall.Name = "flpPunchWall";
            flpPunchWall.Size = new Size(210, 200);
            flpPunchWall.TabIndex = 1;
            // 
            // btnCreateGroupTask
            // 
            btnCreateGroupTask.BackColor = Color.Gold;
            btnCreateGroupTask.FlatAppearance.BorderSize = 0;
            btnCreateGroupTask.FlatStyle = FlatStyle.Flat;
            btnCreateGroupTask.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnCreateGroupTask.ForeColor = Color.LightCoral;
            btnCreateGroupTask.Location = new Point(540, 299);
            btnCreateGroupTask.Name = "btnCreateGroupTask";
            btnCreateGroupTask.Size = new Size(150, 48);
            btnCreateGroupTask.TabIndex = 2;
            btnCreateGroupTask.Text = "创建小组任务";
            btnCreateGroupTask.UseVisualStyleBackColor = false;
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
            labelTitle.Text = "学习小组";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GroupForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(labelTitle);
            Controls.Add(lvGroups);
            Controls.Add(flpPunchWall);
            Controls.Add(btnCreateGroupTask);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "GroupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "学习小组";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}