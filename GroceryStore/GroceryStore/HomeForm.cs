using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStore
{
    public partial class HomeForm : Form
    {
        private DTO_User user;
        public HomeForm(DTO_User user)
        {
            InitializeComponent();
            this.user = user;
        }

        ProductItem[] ProductItem;
        List<ProductOrderItem> orders = new List<ProductOrderItem>();
        List<DTO_Product> list_product = new List<DTO_Product>();
        List<DTO_Voucher> vouchers = new List<DTO_Voucher>();
        String typeOfProduct = "";
        String nameOfProduct = "";
        String[] list_nameProduct;

        //Create event when form loaded
        private void HomeForm_Load(object sender, EventArgs e)
        {

            //gán giá trị cho comboBox
            cbb_payment.SelectedIndex = 0;
            //tạo mảng chưa sản phẩm

            List<DTO_Product> products = new List<DTO_Product>();
            flowLayout.Controls.Clear();

            List<ProductOrderItem> orders = new List<ProductOrderItem>();
            loadProduct(products);
            ProductItem[] listProduct = new ProductItem[products.Count];
            list_product.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listProduct[i] = new ProductItem();
                listProduct[i].NameProduct = products[i].TenSP;
                listProduct[i].PriceProduct = (products[i].GiaSP);

                listProduct[i].ImageProduct = handleUrlImage(products[i].HinhAnh);


                listProduct[i].Click += new System.EventHandler(this.select_Product);
                list_product.Add(products[i]);
                flowLayout.Controls.Add(listProduct[i]);
            }
            ProductItem = listProduct;
        }


        //Load Prodcut to show in homepage
        public void loadProduct(List<DTO_Product> products)
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            bus_listproduct.showAllProduct(products);
        }

        //Load Voucher to show in homepage
        public void loadVoucher(List<DTO_Voucher> vouchers)
        {
            BUS_ListVoucher bus_listvoucher = new BUS_ListVoucher();
            bus_listvoucher.showAllVouchers(vouchers);
        }

        //Load FlowLayout when switch selector
        public void loadFlowLayout(String attribute)
        {
            flowLayout.Controls.Clear();
<<<<<<< HEAD
            List<DTO_Product> products = new List<DTO_Product>();
            btn_tatCa.Visible = false;
            btn_maCuaToi.Visible = false;
            lb_diemTichLuy.Visible = false;
            lb_soDiem.Visible = false;
            lb_chonDanhMuc.Visible = true;
            lb_danhMucPhu.Visible = true;
            lb_tatCa.Visible = true;
            lb_phoBien.Visible = true;
            pb_muiTen.Visible = true;
            loadProduct(list_product, products, type);
=======
            loadProduct(list_product, products, attribute);
>>>>>>> 79ae9c76a8725c3f4efd4895f34207b4c467fa79
            ProductItem[] listProduct = new ProductItem[products.Count];
            for (int i = 0; i < products.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listProduct[i] = new ProductItem();
                listProduct[i].NameProduct = products[i].TenSP;
                listProduct[i].PriceProduct = (products[i].GiaSP);

                listProduct[i].ImageProduct = handleUrlImage(products[i].HinhAnh);

                listProduct[i].Click += new System.EventHandler(this.select_Product);
                flowLayout.Controls.Add(listProduct[i]);
            }
<<<<<<< HEAD
        }

        public void loadformVoucher()
        {
            flowLayout.Controls.Clear();
            btn_tatCa.Visible = true;
            btn_maCuaToi.Visible = true;
            lb_diemTichLuy.Visible = true;
            lb_soDiem.Visible = true;
            lb_chonDanhMuc.Visible = false;
            lb_danhMucPhu.Visible = false;
            lb_tatCa.Visible = false;
            lb_phoBien.Visible = false;
            pb_muiTen.Visible = false;
            loadVoucher(vouchers);
            Voucher[] listVoucher = new Voucher[vouchers.Count];
            for (int i = 0; i < vouchers.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listVoucher[i] = new Voucher();
                listVoucher[i].NameVoucher = vouchers[i].TenVoucher;
                listVoucher[i].PriceVoucher = (vouchers[i].GiaVoucher);
                if (vouchers[i].HinhAnh != "")
                {
                    listVoucher[i].ImageVoucher = handleUrlImage(vouchers[i].HinhAnh);
                }


                //listVoucher[i].Click += new System.EventHandler(this.select_Voucher);
                flowLayout.Controls.Add(listVoucher[i]);
            }
        }


        public void loadProduct(List<DTO_Product> list_products, List<DTO_Product> products, String type)
=======

        }

        //Load product by type
        public void loadProduct(List<DTO_Product> list_products, List<DTO_Product> products, String attribute)
>>>>>>> 79ae9c76a8725c3f4efd4895f34207b4c467fa79
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            if(typeOfProduct != "")
            {
                if(bus_listproduct.getProductsByType(list_products, products, attribute) == 0)
                {
                    MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                }
            }
            else if(nameOfProduct != "")
            {
                if(bus_listproduct.getProductsByName(list_products, products, attribute) == 0)
                {
                    MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                }
            }
        }

<<<<<<< HEAD

=======
        //Load product by name


        //add click event for btn in navigation
        //home page
>>>>>>> 79ae9c76a8725c3f4efd4895f34207b4c467fa79
        private void btn_home_Click(object sender, EventArgs e)
        {
            btn_tatCa.Visible = false;
            btn_maCuaToi.Visible = false;
            typeOfProduct = "";
            HomeForm_Load(sender, e);
            Point currentPosition = btn_home.Location;
            pn_choice.Location = new Point(currentPosition.X + 130, currentPosition.Y + 10);
            pn_choice.BringToFront();
        }

        //drink page
        private void btn_drinks_Click(object sender, EventArgs e)
        {
            Point currentPosition = btn_drinks.Location;
            pn_choice.Location = new Point(255, 255);
            pn_choice.BringToFront();
            typeOfProduct = "DU";
            loadFlowLayout(typeOfProduct);
        }

        //fast food page
        private void btn_fast_foods_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DAV";
            loadFlowLayout(typeOfProduct);
            Point currentPosition = btn_fast_foods.Location;
            pn_choice.Location = new Point(currentPosition.X + 120, currentPosition.Y + 10);
        }

        //others page
        private void btn_others_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DGD";
            loadFlowLayout(typeOfProduct);
            Point currentPosition = btn_others.Location;
            pn_choice.Location = new Point(currentPosition.X + 120, currentPosition.Y + 10);
        }

        private void btn_voucher_Click(object sender, EventArgs e)
        {
            btn_tatCa_Click(sender, e);
            Point currentPosition = btn_others.Location;
            pn_choice.Location = new Point(currentPosition.X + 120, currentPosition.Y + 10);
        }


        //Load image throught link
        private Image handleUrlImage(string urlImage)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(urlImage);
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(stream);
                    return image;
                }
            }
        }

        //function to choose product which is showed in User Interface
        void select_Product(object sender, EventArgs e)
        {
            ProductItem obj = (ProductItem)sender;
            ProductOrderItem order = findProductItem(obj);
            order.NumberOfItem += 1;
            order.Click += new System.EventHandler(this.select_Product_Cart);
            orders.Add(order);
            flowLayoutItemOder.Controls.Add(order);
            calculeteCart();
        }

        ProductOrderItem findProductItem(ProductItem obj)
        {
            foreach (ProductOrderItem item in orders)
            {
                if (item.NameItemOder == obj.NameProduct)
                {
                    return item;
                }
            }
            ProductOrderItem order = new ProductOrderItem();
            order.NameItemOder = obj.NameProduct;
            order.PriceItemOder = obj.PriceProduct;
            order.NumberOfItem = 0;
            return order;
        }


        void select_Product_Cart(object sender, EventArgs e)
        {
            ProductOrderItem obj = (ProductOrderItem)sender;
            obj.NumberOfItem = obj.NumberOfItem;
            if (obj.NumberOfItem <= 0)
            {
                orders.Remove(obj);
                show_product_cart();
            }
            calculeteCart();
        }


        //Calculate total money of user's cart
        void calculeteCart()
        {
            double totalMoney = 0;
            foreach (var item in orders)
            {
                totalMoney += item.PriceItemOder * item.NumberOfItem;
            }
            lb_totalMoney.Text = totalMoney.ToString() + " đ";
            lb_pay.Text = totalMoney.ToString() + " đ";
        }

        //Show product in user's cart
        void show_product_cart()
        {
            flowLayoutItemOder.Controls.Clear();
            foreach (var item in orders)
            {
                flowLayoutItemOder.Controls.Add(item);
            }
        }

        //Responsive for homepage when change size of form
        private void HomeForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 1440)
            {
                panel2.Size = new Size((int)(0.7 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.7 * this.Width), (int)(0.78 * this.Height));
            }
            else
            {
                panel2.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
            }
        }

<<<<<<< HEAD
        private void flowLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_tatCa_Click(object sender, EventArgs e)
        {
            loadformVoucher();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
=======

        //Add search function 
        private void btn_search_Click(object sender, EventArgs e)
        {
            if(tb_search.Text == "")
            {
                HomeForm_Load(sender, e);
            }
            else
            {
                nameOfProduct = tb_search.Text;
                loadFlowLayout(nameOfProduct);
            }
        }

>>>>>>> 79ae9c76a8725c3f4efd4895f34207b4c467fa79
    }
}
