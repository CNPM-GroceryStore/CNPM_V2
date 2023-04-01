namespace GroceryStore
{
    partial class ProductOrderItem
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
            pb_delete = new PictureBox();
            lb_nameItemOder = new Label();
            lb_priceItemOder = new Label();
            pb_plus = new PictureBox();
            pb_minus = new PictureBox();
            lb_totalItem = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pb_delete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_plus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_minus).BeginInit();
            SuspendLayout();
            // 
            // pb_delete
            // 
            pb_delete.Image = Properties.Resources.recycle_bin;
            pb_delete.Location = new Point(6, 19);
            pb_delete.Margin = new Padding(3, 4, 3, 4);
            pb_delete.Name = "pb_delete";
            pb_delete.Size = new Size(46, 53);
            pb_delete.SizeMode = PictureBoxSizeMode.Zoom;
            pb_delete.TabIndex = 0;
            pb_delete.TabStop = false;
            // 
            // lb_nameItemOder
            // 
            lb_nameItemOder.AutoSize = true;
            lb_nameItemOder.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lb_nameItemOder.Location = new Point(69, 7);
            lb_nameItemOder.MaximumSize = new Size(138, 47);
            lb_nameItemOder.MinimumSize = new Size(138, 47);
            lb_nameItemOder.Name = "lb_nameItemOder";
            lb_nameItemOder.Size = new Size(138, 47);
            lb_nameItemOder.TabIndex = 1;
            lb_nameItemOder.Text = "Snack khoai tây";
            lb_nameItemOder.Click += lb_nameItemOder_Click;
            // 
            // lb_priceItemOder
            // 
            lb_priceItemOder.AutoSize = true;
            lb_priceItemOder.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_priceItemOder.Location = new Point(69, 56);
            lb_priceItemOder.Name = "lb_priceItemOder";
            lb_priceItemOder.Size = new Size(74, 23);
            lb_priceItemOder.TabIndex = 2;
            lb_priceItemOder.Text = "15.000 đ";
            // 
            // pb_plus
            // 
            pb_plus.Image = Properties.Resources.plus;
            pb_plus.Location = new Point(299, 28);
            pb_plus.Margin = new Padding(3, 4, 3, 4);
            pb_plus.Name = "pb_plus";
            pb_plus.Size = new Size(29, 33);
            pb_plus.SizeMode = PictureBoxSizeMode.Zoom;
            pb_plus.TabIndex = 3;
            pb_plus.TabStop = false;
            pb_plus.Click += pb_plus_Click;
            // 
            // pb_minus
            // 
            pb_minus.Image = Properties.Resources.minus;
            pb_minus.Location = new Point(389, 28);
            pb_minus.Margin = new Padding(3, 4, 3, 4);
            pb_minus.Name = "pb_minus";
            pb_minus.Size = new Size(29, 33);
            pb_minus.SizeMode = PictureBoxSizeMode.Zoom;
            pb_minus.TabIndex = 4;
            pb_minus.TabStop = false;
            pb_minus.Click += pb_minus_Click;
            // 
            // lb_totalItem
            // 
            lb_totalItem.AutoSize = true;
            lb_totalItem.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_totalItem.ForeColor = Color.FromArgb(248, 9, 9);
            lb_totalItem.Location = new Point(347, 31);
            lb_totalItem.MaximumSize = new Size(26, 27);
            lb_totalItem.MinimumSize = new Size(26, 27);
            lb_totalItem.Name = "lb_totalItem";
            lb_totalItem.Size = new Size(26, 27);
            lb_totalItem.TabIndex = 5;
            lb_totalItem.Tag = "";
            lb_totalItem.Text = "1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(7, 87);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(411, 1);
            panel1.TabIndex = 6;
            // 
            // ProductOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel1);
            Controls.Add(lb_totalItem);
            Controls.Add(pb_minus);
            Controls.Add(pb_plus);
            Controls.Add(lb_priceItemOder);
            Controls.Add(lb_nameItemOder);
            Controls.Add(pb_delete);
            Margin = new Padding(17, 4, 3, 4);
            MinimumSize = new Size(427, 93);
            Name = "ProductOrderItem";
            Size = new Size(427, 93);
            Load += ItemOder_Load;
            ((System.ComponentModel.ISupportInitialize)pb_delete).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_plus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_minus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pb_delete;
        private Label lb_nameItemOder;
        private Label lb_priceItemOder;
        private PictureBox pb_plus;
        private PictureBox pb_minus;
        private Label lb_totalItem;
        private Panel panel1;
    }
}
