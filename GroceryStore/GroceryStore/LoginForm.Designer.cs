namespace GroceryStore
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
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 973);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoCricleK1;
            pictureBox1.Location = new Point(23, 136);
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
            panel2.Location = new Point(641, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(590, 973);
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
            btn_login.Location = new Point(120, 700);
            btn_login.Margin = new Padding(3, 4, 3, 4);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(397, 73);
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
            lb_forgetPassword.Location = new Point(262, 860);
            lb_forgetPassword.Name = "lb_forgetPassword";
            lb_forgetPassword.Size = new Size(139, 20);
            lb_forgetPassword.TabIndex = 14;
            lb_forgetPassword.Text = "Quên mật khẩu";
            lb_forgetPassword.Click += lb_forgetPassword_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(309, 828);
            label2.Name = "label2";
            label2.Size = new Size(29, 20);
            label2.TabIndex = 13;
            label2.Text = "OR";
            // 
            // lb_signUp
            // 
            lb_signUp.AutoSize = true;
            lb_signUp.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lb_signUp.ForeColor = Color.FromArgb(248, 9, 9);
            lb_signUp.Location = new Point(392, 799);
            lb_signUp.Name = "lb_signUp";
            lb_signUp.Size = new Size(79, 20);
            lb_signUp.TabIndex = 12;
            lb_signUp.Text = "Đăng kí";
            lb_signUp.Click += lb_signUp_Click;
            // 
            // lb_account
            // 
            lb_account.AutoSize = true;
            lb_account.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_account.ForeColor = Color.Black;
            lb_account.Location = new Point(176, 797);
            lb_account.Name = "lb_account";
            lb_account.Size = new Size(229, 20);
            lb_account.TabIndex = 11;
            lb_account.Text = "Bạn chưa có tài khoản?";
            // 
            // lb_error
            // 
            lb_error.AutoSize = true;
            lb_error.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_error.ForeColor = Color.FromArgb(248, 9, 9);
            lb_error.Location = new Point(119, 660);
            lb_error.Name = "lb_error";
            lb_error.Size = new Size(0, 20);
            lb_error.TabIndex = 10;
            // 
            // tb_password
            // 
            tb_password.BackColor = Color.White;
            tb_password.BorderStyle = BorderStyle.None;
            tb_password.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_password.Location = new Point(157, 604);
            tb_password.Margin = new Padding(3, 4, 3, 4);
            tb_password.Multiline = true;
            tb_password.Name = "tb_password";
            tb_password.PasswordChar = '*';
            tb_password.Size = new Size(343, 33);
            tb_password.TabIndex = 8;
            tb_password.TextChanged += tb_password_TextChanged;
            // 
            // tb_sdt
            // 
            tb_sdt.BackColor = Color.White;
            tb_sdt.BorderStyle = BorderStyle.None;
            tb_sdt.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_sdt.Location = new Point(157, 489);
            tb_sdt.Margin = new Padding(3, 4, 3, 4);
            tb_sdt.Multiline = true;
            tb_sdt.Name = "tb_sdt";
            tb_sdt.Size = new Size(343, 33);
            tb_sdt.TabIndex = 7;
            tb_sdt.TextChanged += tb_sdt_TextChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.padlock;
            pictureBox4.Location = new Point(117, 591);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(32, 52);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.user;
            pictureBox3.Location = new Point(117, 476);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 52);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(248, 9, 9);
            panel4.Location = new Point(118, 645);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(397, 1);
            panel4.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(248, 9, 9);
            label1.Location = new Point(118, 564);
            label1.Name = "label1";
            label1.Size = new Size(106, 22);
            label1.TabIndex = 3;
            label1.Text = "Mật khẩu";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(248, 9, 9);
            panel3.Location = new Point(118, 531);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(397, 1);
            panel3.TabIndex = 2;
            // 
            // lb_sdt
            // 
            lb_sdt.AutoSize = true;
            lb_sdt.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_sdt.ForeColor = Color.FromArgb(248, 9, 9);
            lb_sdt.Location = new Point(118, 452);
            lb_sdt.Name = "lb_sdt";
            lb_sdt.Size = new Size(166, 22);
            lb_sdt.TabIndex = 1;
            lb_sdt.Text = "Số điện thoại";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_bigZise;
            pictureBox2.Location = new Point(174, 112);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 285);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 921);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(1232, 958);
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