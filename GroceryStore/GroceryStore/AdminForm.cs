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
        List<DTO_Product> products = new List<DTO_Product>();

        private void AdminForm_Load(object sender, EventArgs e)
        {
            showRecentOrder(sender, e);
            showTurnover(sender, e);
            buildChart(sender, e);
            currPage = pn_homepage;
            lb_titilePage.Text = "Trang chủ";
            currPage.Visible = true;
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
        private void switchPage(Object sender, EventArgs e, Guna2CustomGradientPanel nextPage, String titlePage)
        {
            lb_titilePage.Text = titlePage;
            currPage.Visible = false;
            currPage = nextPage;
            currPage.Visible = true;
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_homepage, "Trang chủ");
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

        private void mgmProductPage_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_mgmProduct, "Quản lý sản phẩm");
            MessageBox.Show(products.Count().ToString());
            list_product.showAllProduct(products);
            MessageBox.Show(products.Count().ToString());
            dgv_mgmProduct.DataSource = products;
        }

        private void btn_addProduct_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_addProduct, "Thêm sản phẩm");
        }

        //Add product 
        private void ordersPage_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_orders, "Đơn hàng");
            List<DTO_OrderHistory> orders = bus_OrderHistory.showALl();
            dgv_orders.DataSource = orders;
        }
        private void btn_comfirm_Click(object sender, EventArgs e)
        {
            string name = txb_addNamePro.Text;
            int amount = int.Parse(txb_addAmount.Text);
            int price = int.Parse(txb_addPrice.Text);
            string type = cbb_addtype.Text;
            string shelflife = dtp_addPro.Value.ToString();
            string shipment = txb_shipment.Text;
            StringBuilder sb = new StringBuilder();

            foreach (char c in name.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            string newName = sb.ToString().Normalize(NormalizationForm.FormC).ToLower();
            string image = $"{newName}_{shipment}.jpg";
            image = image.Replace(" ", "_");
            MessageBox.Show(image);

            BUS_Product bUS_Product = new BUS_Product();
            DTO_Product product = new DTO_Product(name, amount, price, image, type, shipment, shelflife);
            MessageBox.Show(product.ToString());
            bUS_Product.insertProduct(product);
        }

        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFileDialog1.FileName);
                ptb_addImagePro.Image = image; StringBuilder sb = new StringBuilder();

                foreach (char c in txb_addNamePro.Text.Normalize(NormalizationForm.FormD))
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                        sb.Append(c);
                }

                string newName = sb.ToString().Normalize(NormalizationForm.FormC).ToLower();
                newName = newName.Replace(" ", "_");
                string fileName = $"{newName}_{txb_shipment.Text}.jpg";
                string savePath = @"..\\..\\..\\Resources\Product\" + cbb_addtype.Text + "\\" + fileName;
                image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void pt_searchPro_Click(object sender, EventArgs e)
        {
            list_product.showAllProduct(products);
            BUS_ListProduct bUS_ListProduct = new BUS_ListProduct();
            List<DTO_Product> list_pro = new List<DTO_Product>();
            bUS_ListProduct.getProductsByName(products, list_pro, txb_searchProduct.Text);
            dgv_mgmProduct.DataSource = list_pro;
        }

        private void btn_cancelAddPro_Click(object sender, EventArgs e)
        {
            mgmProductPage_Click(sender, e);
        }
    }
}
