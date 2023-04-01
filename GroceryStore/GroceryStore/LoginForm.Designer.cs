﻿namespace GroceryStore
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btn_login = new ButtonCustom.Cs_Button();
            lb_forgetPassword = new Label();
            label2 = new Label();
            lb_signUp = new Label();
            lb_account = new Label();
            lb_error = new Label();
            tb_password = new TextBox();
            tb_sdt = new TextBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            lb_sdt = new Label();
            pictureBox2 = new PictureBox();
            errorLogin = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorLogin).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(563, 730);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(20, 102);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btn_login);
            panel2.Controls.Add(lb_forgetPassword);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lb_signUp);
            panel2.Controls.Add(lb_account);
            panel2.Controls.Add(lb_error);
            panel2.Controls.Add(tb_password);
            panel2.Controls.Add(tb_sdt);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(lb_sdt);
            panel2.Controls.Add(pictureBox2);
            panel2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            panel2.ForeColor = Color.Red;
            panel2.Location = new Point(561, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(516, 730);
            panel2.TabIndex = 1;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.FromArgb(248, 9, 9);
            btn_login.BackgroundColor = Color.FromArgb(248, 9, 9);
            btn_login.BorderColor = Color.White;
            btn_login.BorderRadius = 30;
            btn_login.BorderSize = 0;
            btn_login.FlatAppearance.BorderSize = 0;
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_login.ForeColor = Color.White;
            btn_login.Location = new Point(105, 525);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(347, 55);
            btn_login.TabIndex = 15;
            btn_login.Text = "Đăng nhập";
            btn_login.TextColor = Color.White;
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // lb_forgetPassword
            // 
            lb_forgetPassword.AutoSize = true;
            lb_forgetPassword.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lb_forgetPassword.ForeColor = Color.FromArgb(248, 9, 9);
            lb_forgetPassword.Location = new Point(229, 645);
            lb_forgetPassword.Name = "lb_forgetPassword";
            lb_forgetPassword.Size = new Size(111, 16);
            lb_forgetPassword.TabIndex = 14;
            lb_forgetPassword.Text = "Quên mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(270, 621);
            label2.Name = "label2";
            label2.Size = new Size(23, 16);
            label2.TabIndex = 13;
            label2.Text = "OR";
            // 
            // lb_signUp
            // 
            lb_signUp.AutoSize = true;
            lb_signUp.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lb_signUp.ForeColor = Color.FromArgb(248, 9, 9);
            lb_signUp.Location = new Point(343, 599);
            lb_signUp.Name = "lb_signUp";
            lb_signUp.Size = new Size(63, 16);
            lb_signUp.TabIndex = 12;
            lb_signUp.Text = "Đăng kí";
            lb_signUp.Click += lb_signUp_Click;
            // 
            // lb_account
            // 
            lb_account.AutoSize = true;
            lb_account.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_account.ForeColor = Color.Black;
            lb_account.Location = new Point(154, 598);
            lb_account.Name = "lb_account";
            lb_account.Size = new Size(183, 16);
            lb_account.TabIndex = 11;
            lb_account.Text = "Bạn chưa có tài khoản?";
            // 
            // lb_error
            // 
            lb_error.AutoSize = true;
            lb_error.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_error.ForeColor = Color.FromArgb(248, 9, 9);
            lb_error.Location = new Point(104, 495);
            lb_error.Name = "lb_error";
            lb_error.Size = new Size(0, 16);
            lb_error.TabIndex = 10;
            // 
            // tb_password
            // 
            tb_password.BackColor = Color.White;
            tb_password.BorderStyle = BorderStyle.None;
            tb_password.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_password.Location = new Point(137, 453);
            tb_password.Multiline = true;
            tb_password.Name = "tb_password";
            tb_password.PasswordChar = '*';
            tb_password.Size = new Size(300, 25);
            tb_password.TabIndex = 8;
            tb_password.TextChanged += tb_password_TextChanged;
            // 
            // tb_sdt
            // 
            tb_sdt.BackColor = Color.White;
            tb_sdt.BorderStyle = BorderStyle.None;
            tb_sdt.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_sdt.Location = new Point(137, 367);
            tb_sdt.Multiline = true;
            tb_sdt.Name = "tb_sdt";
            tb_sdt.Size = new Size(300, 25);
            tb_sdt.TabIndex = 7;
            tb_sdt.TextChanged += tb_sdt_TextChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.padlock;
            pictureBox4.Location = new Point(102, 443);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(28, 39);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.user;
            pictureBox3.Location = new Point(102, 357);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(28, 39);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(248, 9, 9);
            panel4.Location = new Point(103, 484);
            panel4.Name = "panel4";
            panel4.Size = new Size(347, 1);
            panel4.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(248, 9, 9);
            label1.Location = new Point(103, 423);
            label1.Name = "label1";
            label1.Size = new Size(88, 18);
            label1.TabIndex = 3;
            label1.Text = "Mật khẩu";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(248, 9, 9);
            panel3.Location = new Point(103, 398);
            panel3.Name = "panel3";
            panel3.Size = new Size(347, 1);
            panel3.TabIndex = 2;
            // 
            // lb_sdt
            // 
            lb_sdt.AutoSize = true;
            lb_sdt.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_sdt.ForeColor = Color.FromArgb(248, 9, 9);
            lb_sdt.Location = new Point(103, 339);
            lb_sdt.Name = "lb_sdt";
            lb_sdt.Size = new Size(138, 18);
            lb_sdt.TabIndex = 1;
            lb_sdt.Text = "Số điện thoại";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_bigZise;
            pictureBox2.Location = new Point(152, 84);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(219, 214);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // errorLogin
            // 
            errorLogin.ContainerControl = this;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 691);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1080, 730);
            Name = "LoginForm";
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorLogin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label lb_sdt;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private TextBox tb_password;
        private TextBox tb_sdt;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Label lb_error;
        private Label lb_signUp;
        private Label lb_account;
        private Label lb_forgetPassword;
        private Label label2;
        private ErrorProvider errorLogin;
        private ButtonCustom.Cs_Button btn_login;
    }
}