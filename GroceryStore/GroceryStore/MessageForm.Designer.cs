namespace GroceryStore
{
    partial class MessageForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            panel1 = new Panel();
            label1 = new Label();
            btn_verify = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            lb_sdt = new Label();
            tb_sdt = new Guna.UI2.WinForms.Guna2TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.CustomizableEdges = customizableEdges1;
            guna2ControlBox1.FillColor = Color.Red;
            guna2ControlBox1.HoverState.BorderColor = Color.FromArgb(64, 64, 64);
            guna2ControlBox1.HoverState.IconColor = Color.Black;
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(313, 3);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ControlBox1.Size = new Size(45, 29);
            guna2ControlBox1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(guna2ControlBox1);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 38);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Red;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(99, 19);
            label1.TabIndex = 1;
            label1.Text = "Nhập mã OTP";
            // 
            // btn_verify
            // 
            btn_verify.CustomizableEdges = customizableEdges3;
            btn_verify.DisabledState.BorderColor = Color.DarkGray;
            btn_verify.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_verify.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_verify.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_verify.FillColor = Color.Maroon;
            btn_verify.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_verify.ForeColor = Color.White;
            btn_verify.Location = new Point(122, 139);
            btn_verify.Name = "btn_verify";
            btn_verify.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_verify.Size = new Size(101, 45);
            btn_verify.TabIndex = 3;
            btn_verify.Text = "Xác minh";
            btn_verify.Click += btn_verify_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(77, 50);
            label2.Name = "label2";
            label2.Size = new Size(138, 17);
            label2.TabIndex = 4;
            label2.Text = "OTP đã được gửi đến";
            // 
            // lb_sdt
            // 
            lb_sdt.AutoSize = true;
            lb_sdt.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_sdt.Location = new Point(210, 50);
            lb_sdt.Name = "lb_sdt";
            lb_sdt.Size = new Size(78, 17);
            lb_sdt.TabIndex = 5;
            lb_sdt.Text = "09xxxxxxxx";
            // 
            // tb_sdt
            // 
            tb_sdt.CustomizableEdges = customizableEdges5;
            tb_sdt.DefaultText = "";
            tb_sdt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_sdt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_sdt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_sdt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_sdt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_sdt.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_sdt.ForeColor = Color.Black;
            tb_sdt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_sdt.Location = new Point(94, 82);
            tb_sdt.Name = "tb_sdt";
            tb_sdt.PasswordChar = '\0';
            tb_sdt.PlaceholderText = "OTP của bạn";
            tb_sdt.SelectedText = "";
            tb_sdt.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tb_sdt.Size = new Size(159, 41);
            tb_sdt.TabIndex = 6;
            // 
            // MessageForm
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(360, 196);
            Controls.Add(tb_sdt);
            Controls.Add(lb_sdt);
            Controls.Add(label2);
            Controls.Add(btn_verify);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            HelpButton = true;
            Name = "MessageForm";
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Load += MessageForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_verify;
        private Label label2;
        private Label lb_sdt;
        private Guna.UI2.WinForms.Guna2TextBox tb_sdt;
    }
}