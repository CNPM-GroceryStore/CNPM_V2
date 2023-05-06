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
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Workbook = DocumentFormat.OpenXml.Spreadsheet.Workbook;
using Worksheet = DocumentFormat.OpenXml.Spreadsheet.Worksheet;
using Sheets = DocumentFormat.OpenXml.Spreadsheet.Sheets;
using Color = System.Drawing.Color;

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
            homepage_Click(sender, e);
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
            showRecentOrder(sender, e);
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

        //Go to Add product page
        private void btn_addProduct_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_addProduct, btn_mgmProductPage, "Thêm sản phẩm");
        }

        //Remove Product
        private void dgv_mgmProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow currentRow = dgv_mgmProduct.Rows[e.RowIndex];
                DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

                if (currentCell == currentRow.Cells[currentRow.Cells.Count - 1])
                {
                    DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi danh sách!", "Thông báo", MessageBoxButtons.YesNo);
                    BUS_Product bUS_Product = new BUS_Product();
                    if (dialog == DialogResult.Yes)
                    {
                        bUS_Product.deleteProduct(products[e.RowIndex]);
                        mgmProductPage_Click(sender, e);
                    }
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
                else if (dgv_mgmProduct.Columns[e.ColumnIndex].Name == "Sửa")
                {
                    DataGridViewRow selectedRow = dgv_mgmProduct.CurrentRow;
                    selectedProduct = products[e.RowIndex];
                    switchPage(sender, e, pn_addProduct, btn_mgmProductPage, "Sửa sản phẩm");
                    txb_addNamePro.Text = selectedProduct.NameProduct;
                    txb_addPrice.Text = selectedProduct.PriceProduct.ToString();
                    cbb_addtype.Text = selectedProduct.TypeProduct;
                    dtp_addPro.Text = selectedProduct.Shelflife;
                    txb_shipment.Text = selectedProduct.Shipment;
                    txb_addAmount.Text = selectedProduct.Amount.ToString();
                }

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
            string supplier = cbb_supplier.Text;

            string image = null;
            if (ptb_addImagePro.Image == null)
            {
                image = selectedProduct.ImageProduct;
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
                DTO_Product product = new DTO_Product(name, amount, price, image, type, shipment, shelflife, supplier);
                bUS_Product.insertProduct(product);
                MessageBox.Show("Thêm sản phẩm thành công");
            }
            else if (lb_titilePage.Text == "Sửa sản phẩm")
            {
                BUS_Product bUS_Product = new BUS_Product();
                DTO_Product product = new DTO_Product(selectedProduct.IdProduct, name, amount, price, image, type, shipment, shelflife);
                MessageBox.Show(product.NameProduct);
                bUS_Product.updateProduct(product);
                MessageBox.Show("Sửa sản phẩm thành công");
            }

            string[] checkString = { name, type, shelflife, shipment, supplier, image };
            int[] checkInt = { amount, price };
            if (this.checkIntInput(checkInt) && this.checkStringInput(checkString))
            {

                BUS_Product bUS_Product = new BUS_Product();
                DTO_Product product = new DTO_Product(name, amount, price, image, type, shipment, shelflife, supplier);
                bUS_Product.insertProduct(product);
            }
            else
            {
                MessageBox.Show("Nhập sai quy định, vui lòng nhập lại!");
            }
        }

        //Check string input
        private bool checkStringInput(string[] str)
        {
            foreach (string str2 in str)
            {
                if (str2 == "")
                {
                    return false;
                }
            }
            return true;
        }

        //check int input
        private bool checkIntInput(int[] lst_int)
        {
            foreach (int i in lst_int)
            {
                if (i == 0 || i == null)
                {
                    return false;
                }
            }
            return true;
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

        //------------------------------------------------------------------------------------------------------------

        //Go to managing client page
        private void btn_mngClient_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_mngClient, btn_mngClient, "Quán lí khách hàng");
            BUS_User user = new BUS_User();
            dgv_mngClient.DataSource = user.showAllUser();
        }

        //------------------------------------------------------------------------------------------------------------

        //Go to managing suppllier page
        private void btn_mngSupplier_Click(object sender, EventArgs e)
        {
            switchPage(sender, e, pn_supplier, btn_mngSupplier, "Nhà cung cấp");
            BUS_Supplier bUS_Supplier = new BUS_Supplier();
            dgv_supplier.DataSource = bUS_Supplier.getSupplier();
        }


        private void btn_printStatic_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng SpreadsheetDocument với tên tệp Excel mới
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(@"..\\..\\..\\Resources\Excel\output.xlsx", SpreadsheetDocumentType.Workbook))
            {
                // Tạo một WorkbookPart và thêm nó vào SpreadsheetDocument
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Tạo một WorksheetPart và thêm nó vào WorkbookPart
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                // Tạo một Sheets object để chứa danh sách các Sheets
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());

                // Tạo một Sheet object với tên là "Sheet1" và SheetId mới
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"
                };
                sheets.Append(sheet);

                // Lấy SheetData object để thêm dữ liệu
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Tạo hàng đầu tiên với các tiêu đề cột
                Row headerRow = new Row();
                foreach (DataGridViewColumn column in dgv_staticByMonth.Columns)
                {
                    MessageBox.Show("column: " + column.HeaderText);
                    headerRow.AppendChild(new Cell(new CellValue(column.HeaderText)));
                }
                sheetData.AppendChild(headerRow);

                // Thêm dữ liệu từ DataGridView vào SheetData
                foreach (DataGridViewRow row in dgv_staticByMonth.Rows)
                {
                    Row dataRow = new Row();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if(cell.Value != null)
                        {
                            MessageBox.Show("Cell: " + cell.Value);
                            object value = cell.Value;
                            Cell cellObject;
                            if (value is DateTime)
                            {
                                // Ép kiểu giá trị về DateTime
                                DateTime dateValue = (DateTime)value;
                                // Chuyển đổi DateTime thành chuỗi với định dạng Excel mong đợi
                                string stringValue = dateValue.ToString("MM/dd/yyyy");
                                MessageBox.Show(stringValue);
                                // Tạo đối tượng Cell với giá trị kiểu chuỗi
                                cellObject = new Cell(new CellValue(stringValue));
                            }
                            else
                            {
                                // Giá trị không phải thời gian, tạo đối tượng Cell với giá trị kiểu chuỗi
                                cellObject = new Cell(new CellValue(value.ToString()));
                            }
                            dataRow.AppendChild(cellObject);
                        }
                    }
                    sheetData.AppendChild(dataRow);
                }

                // Lưu các thay đổi vào file Excel
                worksheetPart.Worksheet.Save();
            }
        }


    }
}
