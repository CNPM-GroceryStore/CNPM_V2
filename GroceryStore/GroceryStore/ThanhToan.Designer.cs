namespace GroceryStore
{
    partial class ThanhToan
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
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btn_Mua = new Guna.UI2.WinForms.Guna2Button();
            lb_pay = new Label();
            label15 = new Label();
            lb_soDiemTichLuy = new Label();
            label13 = new Label();
            lb_voucher = new Label();
            lb_maGiamgia = new Label();
            lb_totalMoney = new Label();
            lb_TongTien = new Label();
            guna2ShadowPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.Anchor = AnchorStyles.Right;
            guna2ShadowPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(btn_Mua);
            guna2ShadowPanel2.Controls.Add(lb_pay);
            guna2ShadowPanel2.Controls.Add(label15);
            guna2ShadowPanel2.Controls.Add(lb_soDiemTichLuy);
            guna2ShadowPanel2.Controls.Add(label13);
            guna2ShadowPanel2.Controls.Add(lb_voucher);
            guna2ShadowPanel2.Controls.Add(lb_maGiamgia);
            guna2ShadowPanel2.Controls.Add(lb_totalMoney);
            guna2ShadowPanel2.Controls.Add(lb_TongTien);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(0, -2);
            guna2ShadowPanel2.Margin = new Padding(3, 4, 3, 4);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 7;
            guna2ShadowPanel2.ShadowColor = SystemColors.Control;
            guna2ShadowPanel2.ShadowShift = 1;
            guna2ShadowPanel2.Size = new Size(458, 332);
            guna2ShadowPanel2.TabIndex = 0;
            // 
            // btn_Mua
            // 
            btn_Mua.BorderRadius = 10;
            btn_Mua.CustomizableEdges = customizableEdges1;
            btn_Mua.DisabledState.BorderColor = Color.DarkGray;
            btn_Mua.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Mua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Mua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Mua.FillColor = Color.FromArgb(248, 9, 9);
            btn_Mua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Mua.ForeColor = Color.White;
            btn_Mua.Location = new Point(110, 203);
            btn_Mua.Margin = new Padding(3, 4, 3, 4);
            btn_Mua.Name = "btn_Mua";
            btn_Mua.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Mua.Size = new Size(206, 60);
            btn_Mua.TabIndex = 8;
            btn_Mua.Text = "Mua ngay";
            btn_Mua.Click += btn_Mua_Click;
            // 
            // lb_pay
            // 
            lb_pay.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_pay.ForeColor = Color.FromArgb(248, 9, 9);
            lb_pay.Location = new Point(341, 154);
            lb_pay.Name = "lb_pay";
            lb_pay.Size = new Size(91, 27);
            lb_pay.TabIndex = 7;
            lb_pay.Text = "0 đ";
            lb_pay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(26, 152);
            label15.Name = "label15";
            label15.Size = new Size(116, 28);
            label15.TabIndex = 6;
            label15.Text = "Thanh toán";
            // 
            // lb_soDiemTichLuy
            // 
            lb_soDiemTichLuy.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_soDiemTichLuy.ForeColor = Color.FromArgb(248, 9, 9);
            lb_soDiemTichLuy.Location = new Point(341, 113);
            lb_soDiemTichLuy.Name = "lb_soDiemTichLuy";
            lb_soDiemTichLuy.Size = new Size(91, 27);
            lb_soDiemTichLuy.TabIndex = 5;
            lb_soDiemTichLuy.Text = "0 đ";
            lb_soDiemTichLuy.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(26, 111);
            label13.Name = "label13";
            label13.Size = new Size(132, 28);
            label13.TabIndex = 4;
            label13.Text = "Điểm tích lũy";
            // 
            // lb_voucher
            // 
            lb_voucher.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_voucher.ForeColor = Color.FromArgb(248, 9, 9);
            lb_voucher.Location = new Point(341, 69);
            lb_voucher.Name = "lb_voucher";
            lb_voucher.Size = new Size(91, 27);
            lb_voucher.TabIndex = 3;
            lb_voucher.Text = "0 đ";
            lb_voucher.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lb_maGiamgia
            // 
            lb_maGiamgia.AutoSize = true;
            lb_maGiamgia.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_maGiamgia.ForeColor = Color.Black;
            lb_maGiamgia.Location = new Point(26, 67);
            lb_maGiamgia.Name = "lb_maGiamgia";
            lb_maGiamgia.Size = new Size(124, 28);
            lb_maGiamgia.TabIndex = 2;
            lb_maGiamgia.Text = "Mã giảm giá";
            // 
            // lb_totalMoney
            // 
            lb_totalMoney.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_totalMoney.Location = new Point(341, 29);
            lb_totalMoney.Name = "lb_totalMoney";
            lb_totalMoney.Size = new Size(91, 27);
            lb_totalMoney.TabIndex = 1;
            lb_totalMoney.Text = "0 đ";
            lb_totalMoney.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lb_TongTien
            // 
            lb_TongTien.AutoSize = true;
            lb_TongTien.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_TongTien.ForeColor = Color.Black;
            lb_TongTien.Location = new Point(26, 27);
            lb_TongTien.Name = "lb_TongTien";
            lb_TongTien.Size = new Size(100, 28);
            lb_TongTien.TabIndex = 0;
            lb_TongTien.Text = "Tổng tiền";
            // 
            // ThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(guna2ShadowPanel2);
            Name = "ThanhToan";
            Size = new Size(458, 335);
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2Button btn_Mua;
        private Label lb_pay;
        private Label label15;
        private Label lb_soDiemTichLuy;
        private Label label13;
        private Label lb_voucher;
        private Label lb_maGiamgia;
        private Label lb_totalMoney;
        private Label lb_TongTien;
    }
}
