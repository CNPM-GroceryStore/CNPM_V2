namespace GroceryStore
{
    partial class DiemTichLuy
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
            lb_diemTichLuy = new Label();
            lb_soDiemTichLuy = new Label();
            SuspendLayout();
            // 
            // lb_diemTichLuy
            // 
            lb_diemTichLuy.AutoSize = true;
            lb_diemTichLuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lb_diemTichLuy.ForeColor = Color.Red;
            lb_diemTichLuy.Location = new Point(0, 0);
            lb_diemTichLuy.Name = "lb_diemTichLuy";
            lb_diemTichLuy.Size = new Size(105, 20);
            lb_diemTichLuy.TabIndex = 9;
            lb_diemTichLuy.Text = "Điểm tích lũy:";
            lb_diemTichLuy.Click += label1_Click;
            // 
            // lb_soDiemTichLuy
            // 
            lb_soDiemTichLuy.AutoSize = true;
            lb_soDiemTichLuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lb_soDiemTichLuy.Location = new Point(111, 0);
            lb_soDiemTichLuy.Name = "lb_soDiemTichLuy";
            lb_soDiemTichLuy.Size = new Size(18, 20);
            lb_soDiemTichLuy.TabIndex = 10;
            lb_soDiemTichLuy.Text = "0";
            // 
            // DiemTichLuy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lb_soDiemTichLuy);
            Controls.Add(lb_diemTichLuy);
            Name = "DiemTichLuy";
            Size = new Size(150, 27);
            Load += DiemTichLuy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_diemTichLuy;
        private Label lb_soDiemTichLuy;
    }
}
