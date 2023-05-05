using BUS;
using BUS_1;
using DTO;
using GroceryStore.BUS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using TheArtOfDevHtmlRenderer.Adapters;

namespace GroceryStore
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        BUS_OrderHistory bus_OrderHistory = new BUS_OrderHistory();
        BUS_ListProduct list_product = new BUS_ListProduct();
        Guna2CustomGradientPanel currPage = new Guna2CustomGradientPanel();
        Guna2GradientButton currButton = new Guna2GradientButton();
        List<DTO_Product> products = new List<DTO_Product>();
        DTO_Product selectedProduct = null;
        Bitmap selectedImage = null;

        private void AdminForm_Load(object sender, EventArgs e)
        {
            showRecentOrder(sender, e);
            showTurnover(sender, e);
            buildChart(sender, e);
            currPage = pn_homepage;
            lb_titilePage.Text = "Trang chủ";
            currPage.Visible = true;
            switchPage(sender, e, pn_homepage, btn_homepage, "Trang chủ");
        }

        //show 5 most recent order
        public void showRecentOrder(Object sender, EventArgs e)
        {
            DataTable table = bus_OrderHistory.getRecentOrder();
            dgv_order.DataSource = table;
        }
        //Show turnover: doanh thu
        public void showTurnover(Object sender, EventArgs e)
        {
            lb_turnover_month.Text = bus_OrderHistory.getTurnover().ToString();
        }

        //switch page
        private void switchPage(Object sender, EventArgs e, Guna2CustomGradientPanel nextPage, Guna2GradientButton nextButton, String titlePage)
        {
            lb_titilePage.Text = titlePage;
            currPage.Visible = false;

            currButton.FillColor = Color.White;
            currButton.FillColor2 = Color.White;

            currPage = nextPage;
            currButton = nextButton;


            currButton.FillColor = ColorTranslator.FromHtml("#F80909");
            currButton.FillColor2 = ColorTranslator.FromHtml("#F80909");
            currPage.Visible = true;
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_homepage, btn_homepage, "Trang chủ");
            showTurnover(sender, e);
            buildChart(sender, e);
        }

        // build chart by current month
        private void buildChart(Object sender, EventArgs e)
        {
            DataTable data = bus_OrderHistory.getDataTurnoverOfMonth();
            chart_turnover.Titles.Clear();
            chart_turnover.DataSource = data;
            chart_turnover.Titles.Add("Doanh thu tháng " + DateTime.Now.Month);
            chart_turnover.Series["Doanh thu"].XValueMember = "Date";
            chart_turnover.Series["Doanh thu"].YValueMembers = "Turnover";

            chart_turnover.Series["Doanh thu"].ChartType = SeriesChartType.Line;

            //Set the X and Y axis titles
            chart_turnover.ChartAreas[0].AxisX.Title = "Ngày";
            chart_turnover.ChartAreas[0].AxisY.Title = "Doanh thu";

            // Bind the data to the chart
            chart_turnover.DataBind();
        }


        //------------------------------------------------------------------------------------------------------------

        //Go to orders page -- orders in date
        private void ordersPage_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_ordersInDate, btn_ordersPage, "Đơn hàng");
            BUS_OrderHistory bUS_OrderHistory = new BUS_OrderHistory();
            dgv_orders.DataSource = bUS_OrderHistory.getOrdersInDate();
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Go to static page -- all orders
        private void btn_staticpage_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_staticPage, btn_staticpage, "Thống kê đơn hàng");
            BUS_OrderHistory bUS_OrderHistory = new BUS_OrderHistory();
            dgv_staticByMonth.DataSource = bUS_OrderHistory.getOrdersByMonth(dtp_choseTime.Value.Month);
        }

        //------------------------------------------------------------------------------------------------------------

        //Go to managing product page
        private void mgmProductPage_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_mgmProduct, btn_mgmProductPage, "Quản lý sản phẩm");
            list_product.showAllProductAdmin(products);
            dgv_mgmProduct.DataSource = null;

            // Remove any existing columns
            dgv_mgmProduct.Columns.Clear();
            dgv_mgmProduct.ReadOnly = true;


            // Khóa từng cột trong DataGridView
            foreach (DataGridViewColumn col in dgv_mgmProduct.Columns)
            {
                col.ReadOnly = true;
            }

            // Add columns for product information
            dgv_mgmProduct.DataSource = list_product.showProductsManagePage();

            // Add "Edit", "Save" and "Cancel" buttons for each row
            DataGridViewButtonColumn column_edit = new DataGridViewButtonColumn();
            column_edit.Name = "Sửa";
            column_edit.HeaderText = "Sửa";
            column_edit.Text = "Sửa";
            column_edit.UseColumnTextForButtonValue = true;
            dgv_mgmProduct.Columns.Insert(dgv_mgmProduct.Columns.Count, column_edit);

            DataGridViewButtonColumn column_remove = new DataGridViewButtonColumn();
            column_remove.Name = "Xóa";
            column_remove.HeaderText = "Xóa";
            column_remove.Text = "Xóa";
            column_remove.UseColumnTextForButtonValue = true;

            dgv_mgmProduct.Columns.Insert(dgv_mgmProduct.Columns.Count, column_remove);
        }

        //Remove Product
        private void dgv_mgmProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow currentRow = dgv_mgmProduct.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];
            if (currentCell == currentRow.Cells[currentRow.Cells.Count - 1])
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi danh sách!", "Thông báo", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    BUS_Product bUS_Product = new BUS_Product();
                    string filePath = @"..\\..\\..\\Resources\Product\" + currentRow.Cells[5].Value + "\\" + currentRow.Cells[4].Value;
                    MessageBox.Show(filePath);
                    if (File.Exists(filePath)) // kiểm tra xem file có tồn tại không
                    {
                        File.Delete(filePath); // xóa file nếu tồn tại
                        MessageBox.Show("Xóa trong folder");
                    }
                    bUS_Product.deleteProduct(products[e.RowIndex]);
                    mgmProductPage_Click(sender, e);
                }
            }
            else if (dgv_mgmProduct.Columns[e.ColumnIndex].Name == "Sửa")
            {
                DataGridViewRow selectedRow = dgv_mgmProduct.CurrentRow;
                selectedProduct = products[e.RowIndex];
                switchPage(sender, e, pn_addProduct, btn_mgmProductPage, "Sửa sản phẩm");
                txb_addNamePro.Text = selectedProduct.TenSP;
                txb_addPrice.Text = selectedProduct.GiaSP.ToString();
                cbb_addtype.Text = selectedProduct.LoaiSP;
                dtp_addPro.Text = selectedProduct.Shelflife;
                txb_shipment.Text = selectedProduct.Shipment;
                txb_addAmount.Text = selectedProduct.Amount.ToString();
                MessageBox.Show("click Sửa");
            }
        }


        //Confirm add product
        private void btn_comfirm_Click(object sender, EventArgs e)
        {
            string name = txb_addNamePro.Text;
            int amount = int.Parse(txb_addAmount.Text);
            int price = int.Parse(txb_addPrice.Text);
            string type = cbb_addtype.Text;
            string shelflife = dtp_addPro.Value.ToString();
            string shipment = txb_shipment.Text;
            string image = null;
            if (ptb_addImagePro.Image == null)
            {
                image = selectedProduct.HinhAnh;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in name.Normalize(NormalizationForm.FormD))
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                        sb.Append(c);
                }
                string newName = sb.ToString().Normalize(NormalizationForm.FormC).ToLower();
                newName = newName.Replace(" ", "_");
                image = $"{newName}_{shipment}.jpg";
                image = image.Replace(" ", "_");
                string fileName = $"{newName}_{txb_shipment.Text}.jpg";
                string savePath = @"..\\..\\..\\Resources\Product\" + cbb_addtype.Text + "\\" + fileName;
                selectedImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            if (lb_titilePage.Text == "Thêm sản phẩm")
            {
                BUS_Product bUS_Product = new BUS_Product();
                DTO_Product product = new DTO_Product(name, amount, price, image, type, shipment, shelflife);
                bUS_Product.insertProduct(product);
                MessageBox.Show("Thêm sản phẩm thành công");
            }
            else if (lb_titilePage.Text == "Sửa sản phẩm")
            {
                BUS_Product bUS_Product = new BUS_Product();
                DTO_Product product = new DTO_Product(selectedProduct.MaSP, name, amount, price, image, type, shipment, shelflife);
                MessageBox.Show(product.TenSP);
                bUS_Product.updateProduct(product);
                MessageBox.Show("Sửa sản phẩm thành công");
            }

        }

        //upload image product
        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedImage = new Bitmap(openFileDialog1.FileName);
                ptb_addImagePro.Image = selectedImage;
            }
        }

        //Cancel adding product
        private void btn_cancelAddPro_Click(object sender, EventArgs e)
        {
            mgmProductPage_Click(sender, e);
        }

        //Search list products
        private void pt_searchPro_Click(object sender, EventArgs e)
        {
            list_product.showAllProductAdmin(products);
            BUS_ListProduct bUS_ListProduct = new BUS_ListProduct();
            List<DTO_Product> list_pro = new List<DTO_Product>();
            bUS_ListProduct.getProductsByName(products, list_pro, txb_searchProduct.Text);
            dgv_mgmProduct.DataSource = null;
            dgv_mgmProduct.Columns.Clear();
            dgv_mgmProduct.DataSource = list_pro;
            DataGridViewButtonColumn column_remove = new DataGridViewButtonColumn();
            column_remove.Name = "Thao tác";
            column_remove.HeaderText = "Thao tác";
            column_remove.Text = "Xóa";
            column_remove.UseColumnTextForButtonValue = true;

            dgv_mgmProduct.Columns.Insert(dgv_mgmProduct.Columns.Count, column_remove);
        }

    }
}
