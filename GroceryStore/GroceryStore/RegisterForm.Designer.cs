namespace GroceryStore
{
    partial class RegisterForm
    {
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            lb_error = new Label();
            tb_address = new TextBox();
            panel8 = new Panel();
            label5 = new Label();
            btn_register = new ButtonCustom.Cs_Button();
            tb_confirmPassword = new TextBox();
            panel7 = new Panel();
            label4 = new Label();
            tb_password = new TextBox();
            panel6 = new Panel();
            label3 = new Label();
            tb_name = new TextBox();
            panel5 = new Panel();
            label2 = new Label();
            tb_email = new TextBox();
            panel4 = new Panel();
            label1 = new Label();
            tb_sdt = new TextBox();
            panel3 = new Panel();
            lb_sdt = new Label();
            pictureBox2 = new PictureBox();
            errorRegister = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorRegister).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(645, 973);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoCricleK;
            pictureBox1.Location = new Point(23, 136);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 512);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lb_error);
            panel2.Controls.Add(tb_address);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btn_register);
            panel2.Controls.Add(tb_confirmPassword);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(tb_password);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(tb_name);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(tb_email);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tb_sdt);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(lb_sdt);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(645, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(590, 973);
            panel2.TabIndex = 1;
            // 
            // lb_error
            // 
            lb_error.AutoSize = true;
            lb_error.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lb_error.ForeColor = Color.Red;
            lb_error.Location = new Point(95, 799);
            lb_error.Name = "lb_error";
            lb_error.Size = new Size(0, 17);
            lb_error.TabIndex = 29;
            // 
            // tb_address
            // 
            tb_address.BackColor = Color.White;
            tb_address.BorderStyle = BorderStyle.None;
            tb_address.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_address.Location = new Point(95, 548);
            tb_address.Margin = new Padding(3, 4, 3, 4);
            tb_address.Multiline = true;
            tb_address.Name = "tb_address";
            tb_address.Size = new Size(397, 33);
            tb_address.TabIndex = 28;
            tb_address.TextChanged += tb_address_TextChanged;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(248, 9, 9);
            panel8.Location = new Point(95, 585);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(397, 1);
            panel8.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(248, 9, 9);
            label5.Location = new Point(93, 505);
            label5.Name = "label5";
            label5.Size = new Size(94, 22);
            label5.TabIndex = 26;
            label5.Text = "Địa chỉ";
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.FromArgb(248, 9, 9);
            btn_register.BackgroundColor = Color.FromArgb(248, 9, 9);
            btn_register.BorderColor = Color.PaleVioletRed;
            btn_register.BorderRadius = 20;
            btn_register.BorderSize = 0;
            btn_register.FlatAppearance.BorderSize = 0;
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_register.ForeColor = Color.White;
            btn_register.Location = new Point(93, 837);
            btn_register.Margin = new Padding(3, 4, 3, 4);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(397, 73);
            btn_register.TabIndex = 25;
            btn_register.Text = "Đăng kí";
            btn_register.TextColor = Color.White;
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn_register_Click;
            // 
            // tb_confirmPassword
            // 
            tb_confirmPassword.BackColor = Color.White;
            tb_confirmPassword.BorderStyle = BorderStyle.None;
            tb_confirmPassword.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_confirmPassword.Location = new Point(95, 748);
            tb_confirmPassword.Margin = new Padding(3, 4, 3, 4);
            tb_confirmPassword.Multiline = true;
            tb_confirmPassword.Name = "tb_confirmPassword";
            tb_confirmPassword.PasswordChar = '*';
            tb_confirmPassword.Size = new Size(397, 33);
            tb_confirmPassword.TabIndex = 24;
            tb_confirmPassword.TextChanged += tb_confirmPassword_TextChanged;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(248, 9, 9);
            panel7.Location = new Point(95, 785);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(397, 1);
            panel7.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(248, 9, 9);
            label4.Location = new Point(93, 705);
            label4.Name = "label4";
            label4.Size = new Size(214, 22);
            label4.TabIndex = 22;
            label4.Text = "Nhập lại mật khẩu";
            // 
            // tb_password
            // 
            tb_password.BackColor = Color.White;
            tb_password.BorderStyle = BorderStyle.None;
            tb_password.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_password.Location = new Point(95, 647);
            tb_password.Margin = new Padding(3, 4, 3, 4);
            tb_password.Multiline = true;
            tb_password.Name = "tb_password";
            tb_password.PasswordChar = '*';
            tb_password.Size = new Size(397, 33);
            tb_password.TabIndex = 21;
            tb_password.TextChanged += tb_password_TextChanged;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(248, 9, 9);
            panel6.Location = new Point(95, 684);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(397, 1);
            panel6.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(248, 9, 9);
            label3.Location = new Point(93, 604);
            label3.Name = "label3";
            label3.Size = new Size(166, 22);
            label3.TabIndex = 19;
            label3.Text = "Nhập mật khẩu";
            // 
            // tb_name
            // 
            tb_name.BackColor = Color.White;
            tb_name.BorderStyle = BorderStyle.None;
            tb_name.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_name.Location = new Point(95, 440);
            tb_name.Margin = new Padding(3, 4, 3, 4);
            tb_name.Multiline = true;
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(397, 33);
            tb_name.TabIndex = 18;
            tb_name.TextChanged += tb_name_TextChanged;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(248, 9, 9);
            panel5.Location = new Point(95, 477);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(397, 1);
            panel5.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(248, 9, 9);
            label2.Location = new Point(93, 397);
            label2.Name = "label2";
            label2.Size = new Size(118, 22);
            label2.TabIndex = 16;
            label2.Text = "Họ và tên";
            // 
            // tb_email
            // 
            tb_email.BackColor = Color.White;
            tb_email.BorderStyle = BorderStyle.None;
            tb_email.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_email.Location = new Point(95, 339);
            tb_email.Margin = new Padding(3, 4, 3, 4);
            tb_email.Multiline = true;
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(397, 33);
            tb_email.TabIndex = 15;
            tb_email.TextChanged += tb_email_TextChanged;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(248, 9, 9);
            panel4.Location = new Point(95, 376);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(397, 1);
            panel4.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(248, 9, 9);
            label1.Location = new Point(93, 296);
            label1.Name = "label1";
            label1.Size = new Size(70, 22);
            label1.TabIndex = 13;
            label1.Text = "Email";
            // 
            // tb_sdt
            // 
            tb_sdt.BackColor = Color.White;
            tb_sdt.BorderStyle = BorderStyle.None;
            tb_sdt.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_sdt.Location = new Point(95, 240);
            tb_sdt.Margin = new Padding(3, 4, 3, 4);
            tb_sdt.Multiline = true;
            tb_sdt.Name = "tb_sdt";
            tb_sdt.Size = new Size(397, 33);
            tb_sdt.TabIndex = 12;
            tb_sdt.TextChanged += tb_sdt_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(248, 9, 9);
            panel3.Location = new Point(95, 277);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(397, 1);
            panel3.TabIndex = 9;
            // 
            // lb_sdt
            // 
            lb_sdt.AutoSize = true;
            lb_sdt.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_sdt.ForeColor = Color.FromArgb(248, 9, 9);
            lb_sdt.Location = new Point(93, 197);
            lb_sdt.Name = "lb_sdt";
            lb_sdt.Size = new Size(166, 22);
            lb_sdt.TabIndex = 8;
            lb_sdt.Text = "Số điện thoại";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.signup;
            pictureBox2.Location = new Point(93, 0);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(128, 128);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // errorRegister
            // 
            errorRegister.ContainerControl = this;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 921);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1232, 958);
            Name = "RegisterForm";
            Text = "Đăng kí";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorRegister).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private TextBox tb_sdt;
        private Panel panel3;
        private Label lb_sdt;
        private TextBox tb_confirmPassword;
        private Panel panel7;
        private Label label4;
        private TextBox tb_password;
        private Panel panel6;
        private Label label3;
        private TextBox tb_name;
        private Panel panel5;
        private Label label2;
        private TextBox tb_email;
        private Panel panel4;
        private Label label1;
        private ButtonCustom.Cs_Button btn_register;
        private TextBox tb_address;
        private Panel panel8;
        private Label label5;
        private ErrorProvider errorRegister;
        private Label lb_error;
    }
}