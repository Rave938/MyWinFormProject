using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class NoteForm
    {
        private DataGridView dgvNotes;
        private RichTextBox rtbNote;
        private ComboBox cbTag;
        private TextBox txtSearch;
        private RoundButton btnSearch;
        private RoundButton btnSave;
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
            dgvNotes = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            rtbNote = new RichTextBox();
            cbTag = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new RoundButton();
            btnSave = new RoundButton();
            labelTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // dgvNotes
            // 
            dgvNotes.AllowUserToAddRows = false;
            dgvNotes.AllowUserToDeleteRows = false;
            dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotes.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvNotes.Location = new Point(30, 80);
            dgvNotes.MultiSelect = false;
            dgvNotes.Name = "dgvNotes";
            dgvNotes.ReadOnly = true;
            dgvNotes.RowHeadersWidth = 62;
            dgvNotes.RowTemplate.Height = 40;
            dgvNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotes.Size = new Size(1091, 300);
            dgvNotes.TabIndex = 1;
            dgvNotes.CellClick += DgvNotes_CellClick;
            dgvNotes.CellContentClick += dgvNotes_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "Title"; // 修改为数据库字段名
            dataGridViewTextBoxColumn1.HeaderText = "标题";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "Tag"; // 修改为数据库字段名
            dataGridViewTextBoxColumn2.HeaderText = "标签";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "CreateTime"; // 修改为数据库字段名
            dataGridViewTextBoxColumn3.HeaderText = "创建时间";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "Content"; // 修改为数据库字段名
            dataGridViewTextBoxColumn4.HeaderText = "内容";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 150;
            // 
            // rtbNote
            // 
            rtbNote.Font = new Font("楷体", 13F);
            rtbNote.Location = new Point(1183, 80);
            rtbNote.Name = "rtbNote";
            rtbNote.Size = new Size(350, 200);
            rtbNote.TabIndex = 2;
            rtbNote.Text = "";
            // 
            // cbTag
            // 
            cbTag.Font = new Font("楷体", 13F);
            cbTag.Location = new Point(1183, 300);
            cbTag.Name = "cbTag";
            cbTag.Size = new Size(120, 34);
            cbTag.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("楷体", 13F);
            txtSearch.Location = new Point(30, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 37);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Gold;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnSearch.ForeColor = Color.LightCoral;
            btnSearch.Location = new Point(240, 30);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 37);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "搜索";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Gold;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnSave.ForeColor = Color.LightCoral;
            btnSave.Location = new Point(1433, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 44);
            btnSave.TabIndex = 6;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("楷体", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.IndianRed;
            labelTitle.Location = new Point(650, 23);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(163, 36);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "笔记管理";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1880, 753);
            Controls.Add(labelTitle);
            Controls.Add(dgvNotes);
            Controls.Add(rtbNote);
            Controls.Add(cbTag);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "NoteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "笔记管理";
            Load += NoteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}