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
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.orderHistory;
            pictureBox1.Location = new Point(3, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(76, 80);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(87, 31);
            label10.Name = "label10";
            label10.Size = new Size(36, 23);
            label10.TabIndex = 1;
            label10.Text = "ID: ";
            label10.Click += label10_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(85, 79);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 2;
            label1.Text = "Giá:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(203, 79);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 3;
            label2.Text = " món";
            label2.Click += label2_Click;
            // 
            // lb_paymethod
            // 
            lb_paymethod.AutoSize = true;
            lb_paymethod.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lb_paymethod.Location = new Point(252, 77);
            lb_paymethod.Name = "lb_paymethod";
            lb_paymethod.Size = new Size(77, 23);
            lb_paymethod.TabIndex = 4;
            lb_paymethod.Text = "Tiền mặt";
            lb_paymethod.Click += lb_paymethod_Click;
            // 
            // lb_price
            // 
            lb_price.AutoSize = true;
            lb_price.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lb_price.Location = new Point(123, 79);
            lb_price.Name = "lb_price";
            lb_price.Size = new Size(61, 20);
            lb_price.TabIndex = 5;
            lb_price.Text = "50,000đ";
            lb_price.Click += lb_price_Click;
            // 
            // lb_amount
            // 
            lb_amount.AutoSize = true;
            lb_amount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lb_amount.Location = new Point(190, 80);
            lb_amount.Name = "lb_amount";
            lb_amount.Size = new Size(17, 20);
            lb_amount.TabIndex = 6;
            lb_amount.Text = "1";
            lb_amount.Click += lb_amount_Click;
            // 
            // lb_id
            // 
            lb_id.AutoSize = true;
            lb_id.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lb_id.Location = new Point(122, 31);
            lb_id.Name = "lb_id";
            lb_id.Size = new Size(46, 23);
            lb_id.TabIndex = 7;
            lb_id.Text = "1111";
            lb_id.Click += lb_id_Click;
            // 
            // lb_status
            // 
            lb_status.AutoSize = true;
            lb_status.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lb_status.ForeColor = Color.LimeGreen;
            lb_status.Location = new Point(344, 77);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(105, 25);
            lb_status.TabIndex = 8;
            lb_status.Text = "Hoàn thành";
            lb_status.Click += lb_status_Click;
            // 
            // lb_paydate
            // 
            lb_paydate.AutoSize = true;
            lb_paydate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lb_paydate.Location = new Point(344, 31);
            lb_paydate.Name = "lb_paydate";
            lb_paydate.Size = new Size(87, 23);
            lb_paydate.TabIndex = 9;
            lb_paydate.Text = "14/4/2023";
            lb_paydate.Click += label3_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lb_id);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(lb_paydate);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lb_status);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lb_price);
            panel1.Controls.Add(lb_amount);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lb_paymethod);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 118);
            panel1.TabIndex = 10;
            // 
            // OrderHistoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "OrderHistoryItem";
            Size = new Size(460, 124);
            Load += OrderHistoryItem_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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
        private Panel panel1;
    }
}
