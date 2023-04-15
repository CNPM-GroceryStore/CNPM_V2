namespace GroceryStore
{
    partial class OrderHistoryItem
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
            pictureBox1 = new PictureBox();
            label10 = new Label();
            label1 = new Label();
            label2 = new Label();
            lb_paymethod = new Label();
            lb_price = new Label();
            lb_amount = new Label();
            lb_id = new Label();
            lb_status = new Label();
            lb_paydate = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.orderHistory;
            pictureBox1.Location = new Point(0, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(81, 90);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(91, 23);
            label10.Name = "label10";
            label10.Size = new Size(27, 17);
            label10.TabIndex = 1;
            label10.Text = "ID: ";
            label10.Click += label10_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(91, 57);
            label1.Name = "label1";
            label1.Size = new Size(34, 17);
            label1.TabIndex = 2;
            label1.Text = "Giá: ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(206, 56);
            label2.Name = "label2";
            label2.Size = new Size(38, 17);
            label2.TabIndex = 3;
            label2.Text = " món";
            label2.Click += label2_Click;
            // 
            // lb_paymethod
            // 
            lb_paymethod.AutoSize = true;
            lb_paymethod.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            lb_paymethod.Location = new Point(90, 96);
            lb_paymethod.Name = "lb_paymethod";
            lb_paymethod.Size = new Size(58, 17);
            lb_paymethod.TabIndex = 4;
            lb_paymethod.Text = "Tiền mặt";
            lb_paymethod.Click += lb_paymethod_Click;
            // 
            // lb_price
            // 
            lb_price.AutoSize = true;
            lb_price.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            lb_price.Location = new Point(126, 57);
            lb_price.Name = "lb_price";
            lb_price.Size = new Size(54, 17);
            lb_price.TabIndex = 5;
            lb_price.Text = "50,000đ";
            lb_price.Click += lb_price_Click;
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            lb_amount.Location = new Point(193, 56);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(15, 17);
            lb_amount.TabIndex = 6;
            lb_amount.Text = "1";
            lb_amount.Click += lb_amount_Click;
            // 
            // lb_id
            // 
            lb_id.AutoSize = true;
            lb_id.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lb_id.Location = new Point(126, 23);
            lb_id.Name = "lb_id";
            lb_id.Size = new Size(36, 17);
            lb_id.TabIndex = 7;
            lb_id.Text = "1111";
            lb_id.Click += lb_id_Click;
            // 
            // lb_status
            // 
            lb_status.AutoSize = true;
            lb_status.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lb_status.ForeColor = Color.LimeGreen;
            lb_status.Location = new Point(250, 50);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(101, 23);
            lb_status.TabIndex = 8;
            lb_status.Text = "Hoàn thành";
            lb_status.Click += lb_status_Click;
            // 
            // lb_paydate
            // 
            lb_paydate.AutoSize = true;
            lb_paydate.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lb_paydate.Location = new Point(250, 23);
            lb_paydate.Name = "lb_paydate";
            lb_paydate.Size = new Size(67, 17);
            lb_paydate.TabIndex = 9;
            lb_paydate.Text = "14/4/2023";
            lb_paydate.Click += label3_Click;
            // 
            // OrderHistoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_paydate);
            Controls.Add(lb_status);
            Controls.Add(lb_id);
            Controls.Add(lb_amount);
            Controls.Add(lb_price);
            Controls.Add(lb_paymethod);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label10);
            Controls.Add(pictureBox1);
            Name = "OrderHistoryItem";
            Size = new Size(377, 124);
            Load += OrderHistoryItem_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label10;
        private Label label1;
        private Label label2;
        private Label lb_paymethod;
        private Label lb_price;
        private Label lb_amount;
        private Label lb_id;
        private Label lb_status;
        private Label lb_paydate;
    }
}
