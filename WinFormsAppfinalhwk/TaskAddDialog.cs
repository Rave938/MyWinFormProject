using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    public partial class TaskAddDialog : Form
    {
        private Label lblTitle;
        private Label lblCourse;
        private Label lblDueDate;
        private Label lblPriority;
        private TextBox txtTitle;
        private TextBox txtCourse;
        private DateTimePicker dtpDueDate;
        private ComboBox cmbPriority;
        private CheckBox chkCompleted;
        private Button btnOK;
        private Button btnCancel;

        public string TaskTitle => txtTitle.Text.Trim();
        public string RelatedCourse => txtCourse.Text.Trim();
        public DateTime DueDate => dtpDueDate.Value;
        public string PriorityLevel => cmbPriority.Text;
        public bool IsTaskCompleted => chkCompleted.Checked;

        public TaskAddDialog()
        {
            InitializeComponent();
            if (cmbPriority.Items.Count > 1)
                cmbPriority.SelectedIndex = 1;
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(230, 240, 255);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(400, 320);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "添加任务";

            int labelX = 40;
            int labelWidth = 90;
            int inputX = 140;
            int inputWidth = 200;
            int rowHeight = 45;
            int startY = 30;

            lblTitle = new Label
            {
                Text = "任务名：",
                Location = new Point(labelX, startY + rowHeight * 0),
                Size = new Size(labelWidth, 30),
                Font = new Font("楷体", 13F, FontStyle.Bold),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtTitle = new TextBox
            {
                Location = new Point(inputX, startY + rowHeight * 0),
                Size = new Size(inputWidth, 30),
                Font = new Font("楷体", 13F)
            };

            lblCourse = new Label
            {
                Text = "关联课程：",
                Location = new Point(labelX, startY + rowHeight * 1),
                Size = new Size(labelWidth, 30),
                Font = new Font("楷体", 13F, FontStyle.Bold),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight
            };
            txtCourse = new TextBox
            {
                Location = new Point(inputX, startY + rowHeight * 1),
                Size = new Size(inputWidth, 30),
                Font = new Font("楷体", 13F)
            };

            lblDueDate = new Label
            {
                Text = "截止时间：",
                Location = new Point(labelX, startY + rowHeight * 2),
                Size = new Size(labelWidth, 30),
                Font = new Font("楷体", 13F, FontStyle.Bold),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight
            };
            dtpDueDate = new DateTimePicker
            {
                Location = new Point(inputX, startY + rowHeight * 2),
                Size = new Size(inputWidth, 30),
                Font = new Font("楷体", 13F),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy-MM-dd HH:mm"
            };

            lblPriority = new Label
            {
                Text = "优先级：",
                Location = new Point(labelX, startY + rowHeight * 3),
                Size = new Size(labelWidth, 30),
                Font = new Font("楷体", 13F, FontStyle.Bold),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight
            };
            cmbPriority = new ComboBox
            {
                Location = new Point(inputX, startY + rowHeight * 3),
                Size = new Size(inputWidth, 30),
                Font = new Font("楷体", 13F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPriority.Items.AddRange(new object[] { "高", "中", "低" });

            chkCompleted = new CheckBox
            {
                Text = "已完成",
                Location = new Point(inputX, startY + rowHeight * 4 - 2),
                Font = new Font("楷体", 13F),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            btnOK = new Button
            {
                Text = "确定",
                Location = new Point(80, 240),
                Size = new Size(100, 40),
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.LightCoral,
                Font = new Font("楷体", 13F, FontStyle.Bold),
                DialogResult = DialogResult.OK
            };
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.Click += BtnOK_Click;

            btnCancel = new Button
            {
                Text = "取消",
                Location = new Point(220, 240),
                Size = new Size(100, 40),
                BackColor = Color.Gold,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.LightCoral,
                Font = new Font("楷体", 13F, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblCourse);
            this.Controls.Add(txtCourse);
            this.Controls.Add(lblDueDate);
            this.Controls.Add(dtpDueDate);
            this.Controls.Add(lblPriority);
            this.Controls.Add(cmbPriority);
            this.Controls.Add(chkCompleted);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskTitle) ||
                string.IsNullOrWhiteSpace(RelatedCourse) ||
                string.IsNullOrWhiteSpace(PriorityLevel))
            {
                MessageBox.Show("请填写完整任务信息！");
                this.DialogResult = DialogResult.None;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}