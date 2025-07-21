namespace WinFormsAppfinalhwk
{
    partial class ResetForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            txtVerifyCode = new RoundTextBox();
            txtNewPassword = new RoundTextBox();
            btnReset = new RoundButton();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("楷体", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.IndianRed;
            labelTitle.Location = new Point(1397, 147);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(147, 33);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "密码重置";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("楷体", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(1337, 217);
            label1.Name = "label1";
            label1.Size = new Size(85, 24);
            label1.TabIndex = 2;
            label1.Text = "验证码";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("楷体", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(1337, 267);
            label2.Name = "label2";
            label2.Size = new Size(85, 24);
            label2.TabIndex = 3;
            label2.Text = "新密码";
            // 
            // txtVerifyCode
            // 
            txtVerifyCode.BackColor = Color.White;
            txtVerifyCode.BorderStyle = BorderStyle.FixedSingle;
            txtVerifyCode.Font = new Font("楷体", 12F);
            txtVerifyCode.Location = new Point(1427, 217);
            txtVerifyCode.Name = "txtVerifyCode";
            txtVerifyCode.Size = new Size(180, 35);
            txtVerifyCode.TabIndex = 4;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.White;
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("楷体", 12F);
            txtNewPassword.Location = new Point(1427, 267);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(180, 35);
            txtNewPassword.TabIndex = 5;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Gold;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("楷体", 12F, FontStyle.Bold);
            btnReset.ForeColor = Color.LightCoral;
            btnReset.Location = new Point(1427, 317);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(180, 40);
            btnReset.TabIndex = 6;
            btnReset.Text = "重置密码";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // ResetForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1805, 706);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtVerifyCode);
            Controls.Add(txtNewPassword);
            Controls.Add(btnReset);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ResetForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "重置密码";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Label label2;
        private RoundTextBox txtVerifyCode;
        private RoundTextBox txtNewPassword;
        private RoundButton btnReset;
    }
}