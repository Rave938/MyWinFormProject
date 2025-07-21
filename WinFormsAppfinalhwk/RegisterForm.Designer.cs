using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class RegisterForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtUserId = new RoundTextBox();
            txtPassword = new RoundTextBox();
            txtEmail = new RoundTextBox();
            txtVerifyCode = new RoundTextBox();
            comboGender = new ComboBox();
            comboOrigin = new ComboBox();
            btnSendCode = new RoundButton();
            btnRegister = new RoundButton();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("楷体", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.IndianRed;
            labelTitle.Location = new Point(1439, 109);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(163, 36);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "用户注册";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("楷体", 13F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(1379, 184);
            label1.Name = "label1";
            label1.Size = new Size(66, 26);
            label1.TabIndex = 2;
            label1.Text = "账号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("楷体", 13F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(1379, 234);
            label2.Name = "label2";
            label2.Size = new Size(66, 26);
            label2.TabIndex = 3;
            label2.Text = "密码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("楷体", 13F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(1379, 284);
            label3.Name = "label3";
            label3.Size = new Size(66, 26);
            label3.TabIndex = 4;
            label3.Text = "邮箱";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("楷体", 13F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(1370, 336);
            label4.Name = "label4";
            label4.Size = new Size(93, 26);
            label4.TabIndex = 5;
            label4.Text = "验证码";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("楷体", 13F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(255, 128, 0);
            label5.Location = new Point(1379, 384);
            label5.Name = "label5";
            label5.Size = new Size(66, 26);
            label5.TabIndex = 6;
            label5.Text = "性别";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("楷体", 13F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(255, 128, 0);
            label6.Location = new Point(1379, 434);
            label6.Name = "label6";
            label6.Size = new Size(66, 26);
            label6.TabIndex = 7;
            label6.Text = "籍贯";
            // 
            // txtUserId
            // 
            txtUserId.BackColor = Color.White;
            txtUserId.BorderStyle = BorderStyle.FixedSingle;
            txtUserId.Font = new Font("楷体", 13F);
            txtUserId.Location = new Point(1469, 184);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(180, 37);
            txtUserId.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("楷体", 13F);
            txtPassword.Location = new Point(1469, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 37);
            txtPassword.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("楷体", 13F);
            txtEmail.Location = new Point(1469, 284);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 37);
            txtEmail.TabIndex = 10;
            // 
            // txtVerifyCode
            // 
            txtVerifyCode.BackColor = Color.White;
            txtVerifyCode.BorderStyle = BorderStyle.FixedSingle;
            txtVerifyCode.Font = new Font("楷体", 13F);
            txtVerifyCode.Location = new Point(1469, 334);
            txtVerifyCode.Name = "txtVerifyCode";
            txtVerifyCode.Size = new Size(120, 37);
            txtVerifyCode.TabIndex = 11;
            // 
            // comboGender
            // 
            comboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGender.Font = new Font("楷体", 13F);
            comboGender.Items.AddRange(new object[] { "男", "女", "隐藏" });
            comboGender.Location = new Point(1469, 384);
            comboGender.Name = "comboGender";
            comboGender.Size = new Size(180, 34);
            comboGender.TabIndex = 12;
            // 
            // comboOrigin
            // 
            comboOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOrigin.Font = new Font("楷体", 13F);
            comboOrigin.Items.AddRange(new object[] { "北京", "上海", "广东", "江苏", "隐藏" });
            comboOrigin.Location = new Point(1469, 434);
            comboOrigin.Name = "comboOrigin";
            comboOrigin.Size = new Size(180, 34);
            comboOrigin.TabIndex = 13;
            // 
            // btnSendCode
            // 
            btnSendCode.BackColor = Color.Gold;
            btnSendCode.FlatAppearance.BorderSize = 0;
            btnSendCode.FlatStyle = FlatStyle.Flat;
            btnSendCode.Font = new Font("楷体", 11F, FontStyle.Bold);
            btnSendCode.ForeColor = Color.LightCoral;
            btnSendCode.Location = new Point(1599, 334);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.Size = new Size(50, 32);
            btnSendCode.TabIndex = 14;
            btnSendCode.Text = "发送";
            btnSendCode.UseVisualStyleBackColor = false;
            btnSendCode.Click += btnSendCode_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 255, 128);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("楷体", 14F, FontStyle.Bold);
            btnRegister.ForeColor = Color.LightCoral;
            btnRegister.Location = new Point(1469, 484);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(180, 44);
            btnRegister.TabIndex = 15;
            btnRegister.Text = "注册";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1814, 698);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(txtUserId);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtVerifyCode);
            Controls.Add(comboGender);
            Controls.Add(comboOrigin);
            Controls.Add(btnSendCode);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "注册";
            Load += RegisterForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private RoundTextBox txtUserId;
        private RoundTextBox txtPassword;
        private RoundTextBox txtEmail;
        private RoundTextBox txtVerifyCode;
        private ComboBox comboGender;
        private ComboBox comboOrigin;
        private RoundButton btnSendCode;
        private RoundButton btnRegister;
    }
}