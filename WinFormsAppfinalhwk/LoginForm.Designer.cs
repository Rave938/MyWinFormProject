using System.Drawing;
using System.Windows.Forms;

namespace WinFormsAppfinalhwk
{
    partial class LoginForm
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
            lblUserId = new Label();
            lblPassword = new Label();
            txtUserId = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            btnForgotPwd = new Button();
            chkAutoLogin = new CheckBox();
            SuspendLayout();
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.BackColor = Color.Transparent;
            lblUserId.Font = new Font("楷体", 13F, FontStyle.Bold);
            lblUserId.Location = new Point(1228, 121);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(93, 26);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "账号：";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("楷体", 13F, FontStyle.Bold);
            lblPassword.Location = new Point(1228, 181);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(93, 26);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "密码：";
            // 
            // txtUserId
            // 
            txtUserId.Font = new Font("楷体", 13F);
            txtUserId.Location = new Point(1338, 116);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(200, 37);
            txtUserId.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("楷体", 13F);
            txtPassword.Location = new Point(1338, 176);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 37);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Gold;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("楷体", 13F, FontStyle.Bold);
            btnLogin.ForeColor = Color.LightCoral;
            btnLogin.Location = new Point(1338, 271);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 44);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Font = new Font("楷体", 12F);
            btnRegister.Location = new Point(1320, 331);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(90, 36);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "注册";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnForgotPwd
            // 
            btnForgotPwd.BackColor = Color.Transparent;
            btnForgotPwd.Font = new Font("楷体", 12F);
            btnForgotPwd.Location = new Point(1416, 331);
            btnForgotPwd.Name = "btnForgotPwd";
            btnForgotPwd.Size = new Size(133, 36);
            btnForgotPwd.TabIndex = 6;
            btnForgotPwd.Text = "忘记密码";
            btnForgotPwd.UseVisualStyleBackColor = false;
            btnForgotPwd.Click += btnForgotPwd_Click;
            // 
            // chkAutoLogin
            // 
            chkAutoLogin.AutoSize = true;
            chkAutoLogin.BackColor = Color.Transparent;
            chkAutoLogin.Font = new Font("楷体", 12F);
            chkAutoLogin.Location = new Point(1338, 231);
            chkAutoLogin.Name = "chkAutoLogin";
            chkAutoLogin.Size = new Size(132, 28);
            chkAutoLogin.TabIndex = 4;
            chkAutoLogin.Text = "自动登录";
            chkAutoLogin.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 255);
            ClientSize = new Size(1655, 837);
            Controls.Add(lblUserId);
            Controls.Add(lblPassword);
            Controls.Add(txtUserId);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(btnForgotPwd);
            Controls.Add(chkAutoLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "登录";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserId;
        private Label lblPassword;
        private TextBox txtUserId;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Button btnForgotPwd;
        private CheckBox chkAutoLogin;
    }
}