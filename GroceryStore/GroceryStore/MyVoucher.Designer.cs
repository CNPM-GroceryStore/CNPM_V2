namespace GroceryStore
{
    partial class MyVoucher
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

        #region Component Designer generated code

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
            pb_imageMyVoucher = new PictureBox();
            lb_nameMyVoucher = new Label();
            lb_priceMyVoucher = new Label();
            btn_use = new Guna.UI2.WinForms.Guna2Button();
            lb_soLuong = new Label();
            btn_bo = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pb_imageMyVoucher).BeginInit();
            SuspendLayout();
            // 
            // pb_imageMyVoucher
            // 
            pb_imageMyVoucher.Image = Properties.Resources.icon_item_voucher;
            pb_imageMyVoucher.Location = new Point(6, 8);
            pb_imageMyVoucher.Margin = new Padding(3, 4, 3, 4);
            pb_imageMyVoucher.Name = "pb_imageMyVoucher";
            pb_imageMyVoucher.Size = new Size(70, 75);
            pb_imageMyVoucher.SizeMode = PictureBoxSizeMode.Zoom;
            pb_imageMyVoucher.TabIndex = 0;
            pb_imageMyVoucher.TabStop = false;
            // 
            // lb_nameMyVoucher
            // 
            lb_nameMyVoucher.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lb_nameMyVoucher.ImageAlign = ContentAlignment.TopLeft;
            lb_nameMyVoucher.Location = new Point(82, 8);
            lb_nameMyVoucher.Name = "lb_nameMyVoucher";
            lb_nameMyVoucher.Size = new Size(176, 35);
            lb_nameMyVoucher.TabIndex = 1;
            lb_nameMyVoucher.Text = "Giảm 10k cho đơn 0đ";
            // 
            // lb_priceMyVoucher
            // 
            lb_priceMyVoucher.AutoSize = true;
            lb_priceMyVoucher.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_priceMyVoucher.Location = new Point(82, 60);
            lb_priceMyVoucher.Name = "lb_priceMyVoucher";
            lb_priceMyVoucher.Size = new Size(74, 23);
            lb_priceMyVoucher.TabIndex = 2;
            lb_priceMyVoucher.Text = "15.000 đ";
            // 
            // btn_use
            // 
            btn_use.BorderRadius = 10;
            btn_use.CustomizableEdges = customizableEdges1;
            btn_use.DisabledState.BorderColor = Color.DarkGray;
            btn_use.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_use.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_use.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_use.FillColor = Color.Red;
            btn_use.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_use.ForeColor = Color.White;
            btn_use.Location = new Point(471, 26);
            btn_use.Name = "btn_use";
            btn_use.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_use.Size = new Size(113, 45);
            btn_use.TabIndex = 4;
            btn_use.Text = "Sử dụng";
            btn_use.Click += btn_use_Click;
            // 
            // lb_soLuong
            // 
            lb_soLuong.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lb_soLuong.Location = new Point(562, 80);
            lb_soLuong.Name = "lb_soLuong";
            lb_soLuong.Size = new Size(38, 20);
            lb_soLuong.TabIndex = 5;
            lb_soLuong.Text = "X1";
            lb_soLuong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_bo
            // 
            btn_bo.BackColor = SystemColors.ControlLight;
            btn_bo.BorderColor = Color.LightCoral;
            btn_bo.BorderRadius = 10;
            btn_bo.BorderThickness = 1;
            btn_bo.CustomizableEdges = customizableEdges3;
            btn_bo.DisabledState.BorderColor = Color.DarkGray;
            btn_bo.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_bo.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_bo.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_bo.FillColor = Color.Silver;
            btn_bo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_bo.ForeColor = Color.Red;
            btn_bo.Location = new Point(406, 26);
            btn_bo.Name = "btn_bo";
            btn_bo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_bo.Size = new Size(55, 45);
            btn_bo.TabIndex = 6;
            btn_bo.Text = "Bỏ";
            btn_bo.Visible = false;
            btn_bo.Click += btn_bo_Click;
            // 
            // MyVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(btn_bo);
            Controls.Add(lb_soLuong);
            Controls.Add(btn_use);
            Controls.Add(lb_priceMyVoucher);
            Controls.Add(lb_nameMyVoucher);
            Controls.Add(pb_imageMyVoucher);
            Margin = new Padding(17, 4, 3, 4);
            Name = "MyVoucher";
            Size = new Size(600, 100);
            ((System.ComponentModel.ISupportInitialize)pb_imageMyVoucher).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_imageMyVoucher;
        private Label lb_nameMyVoucher;
        private Label lb_priceMyVoucher;
        private Guna.UI2.WinForms.Guna2Button btn_use;
        private Label lb_soLuong;
        private Guna.UI2.WinForms.Guna2Button btn_bo;
    }
}
