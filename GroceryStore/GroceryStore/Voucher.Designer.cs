namespace GroceryStore
{
    partial class Voucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voucher));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pb_imageVoucher = new PictureBox();
            lb_nameVoucher = new Label();
            lb_priceVoucher = new Label();
            btn_Doi = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pb_imageVoucher).BeginInit();
            SuspendLayout();
            // 
            // pb_imageVoucher
            // 
            pb_imageVoucher.Image = (Image)resources.GetObject("pb_imageVoucher.Image");
            pb_imageVoucher.Location = new Point(6, 8);
            pb_imageVoucher.Margin = new Padding(3, 4, 3, 4);
            pb_imageVoucher.Name = "pb_imageVoucher";
            pb_imageVoucher.Size = new Size(70, 75);
            pb_imageVoucher.SizeMode = PictureBoxSizeMode.Zoom;
            pb_imageVoucher.TabIndex = 0;
            pb_imageVoucher.TabStop = false;
            // 
            // lb_nameVoucher
            // 
            lb_nameVoucher.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lb_nameVoucher.ImageAlign = ContentAlignment.TopLeft;
            lb_nameVoucher.Location = new Point(82, 8);
            lb_nameVoucher.Name = "lb_nameVoucher";
            lb_nameVoucher.Size = new Size(176, 35);
            lb_nameVoucher.TabIndex = 1;
            lb_nameVoucher.Text = "Giảm 10k cho đơn 0đ";
            // 
            // lb_priceVoucher
            // 
            lb_priceVoucher.AutoSize = true;
            lb_priceVoucher.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_priceVoucher.Location = new Point(82, 60);
            lb_priceVoucher.Name = "lb_priceVoucher";
            lb_priceVoucher.Size = new Size(74, 23);
            lb_priceVoucher.TabIndex = 2;
            lb_priceVoucher.Text = "15.000 đ";
            // 
            // btn_Doi
            // 
            btn_Doi.BorderRadius = 10;
            btn_Doi.CustomizableEdges = customizableEdges1;
            btn_Doi.DisabledState.BorderColor = Color.DarkGray;
            btn_Doi.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Doi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Doi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Doi.FillColor = Color.Red;
            btn_Doi.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Doi.ForeColor = Color.White;
            btn_Doi.Location = new Point(491, 18);
            btn_Doi.Name = "btn_Doi";
            btn_Doi.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Doi.Size = new Size(80, 56);
            btn_Doi.TabIndex = 4;
            btn_Doi.Text = "Đổi";
            // 
            // Voucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(btn_Doi);
            Controls.Add(lb_priceVoucher);
            Controls.Add(lb_nameVoucher);
            Controls.Add(pb_imageVoucher);
            Margin = new Padding(17, 4, 3, 4);
            Name = "Voucher";
            Size = new Size(600, 100);
            Load += Voucher_Load;
            ((System.ComponentModel.ISupportInitialize)pb_imageVoucher).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_imageVoucher;
        private Label lb_nameVoucher;
        private Label lb_priceVoucher;
        private Guna.UI2.WinForms.Guna2Button btn_Doi;
    }
}
