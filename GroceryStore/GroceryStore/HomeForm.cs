using BUS;
using DTO;
using GroceryStore.BUS;
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


        List<ProductOrderItem> orders = new List<ProductOrderItem>();
        List<DTO_Product> list_product = new List<DTO_Product>();
        List<DTO_Voucher> vouchers = new List<DTO_Voucher>();
        List<DTO_MyVoucher> myVouchers = new List<DTO_MyVoucher>();
        String typeOfProduct = "home";
        String[] list_nameProduct;

        //Create event when form loaded
        private void HomeForm_Load(object sender, EventArgs e)
        {
            String name = user.NameUser;
            String[] x = name.Split(' ');
            name = x[x.Length - 2] + " " + x[x.Length - 1];
            lb_nameUser2.Text = name;
            lb_nameUser1.Text = name;
            //gán giá trị cho comboBox
            cbb_payment.SelectedIndex = 0;
            //tạo mảng chưa sản phẩm

            List<DTO_Product> products = new List<DTO_Product>();
            flowLayout.Controls.Clear();

            List<ProductOrderItem> orders = new List<ProductOrderItem>();
            loadVoucher(vouchers);
            loadProduct(list_product);
            ProductItem[] listProduct = new ProductItem[list_product.Count];
            loadProductToFlowLayout(list_product);
            ThanhToan.Mua_Clicked += select_Mua;
        }

        //Load Prodcut to show in homepage
        public void loadProduct(List<DTO_Product> products)
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            bus_listproduct.showAllProduct(products);
        }

        public void loadProduct(List<DTO_Product> list_products, List<DTO_Product> products, String nameProduct)
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            if (typeOfProduct != "home")
            {
                if (nameProduct != "")
                {
                    if (bus_listproduct.getProductsByTypeAndName(list_products, products, typeOfProduct, nameProduct) == 0)
                    {
                        MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                    }
                }
                else
                {
                    if (bus_listproduct.getProductsByType(list_products, products, typeOfProduct) == 0)
                    {
                        MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                    }
                }
            }
            else if (nameProduct != "")
            {
                MessageBox.Show("Vao nameProduct");
                if (bus_listproduct.getProductsByName(list_products, products, nameProduct) == 0)
                {
                    MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                }
            }
        }

        //Load FlowLayout when switch selector
        public void loadFlowLayout(String attribute)
        {
            flowLayout.Controls.Clear();
            List<DTO_Product> products = new List<DTO_Product>();
            btn_tatCa.Visible = false;
            btn_maCuaToi.Visible = false;
            DiemTichLuy.Visible = false;
            lb_chonDanhMuc.Visible = true;
            lb_danhMucPhu.Visible = true;
            lb_tatCa.Visible = true;
            lb_phoBien.Visible = true;
            pb_muiTen.Visible = true;
            loadProduct(list_product, products, attribute);
            loadProductToFlowLayout(products);
        }

        public void loadProductToFlowLayout(List<DTO_Product> products)
        {
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
        }

        //Load Voucher to show in homepage
        public void loadVoucher(List<DTO_Voucher> vouchers)
        {
            BUS_ListVoucher bus_listvoucher = new BUS_ListVoucher();
            bus_listvoucher.showAllVouchers(vouchers);
        }
        public void loadformVoucher()
        {
            flowLayout.Controls.Clear();
            btn_tatCa.Visible = true;
            btn_maCuaToi.Visible = true;
            DiemTichLuy.Visible = true;
            lb_chonDanhMuc.Visible = false;
            lb_danhMucPhu.Visible = false;
            lb_tatCa.Visible = false;
            lb_phoBien.Visible = false;
            pb_muiTen.Visible = false;
            DiemTichLuy.Point = user.AccumulatedPointsUser;

            Voucher[] listVoucher = new Voucher[vouchers.Count];
            for (int i = 0; i < vouchers.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listVoucher[i] = new Voucher();
                listVoucher[i].IdVoucher = vouchers[i].MaVoucher;
                listVoucher[i].NameVoucher = vouchers[i].TenVoucher;
                listVoucher[i].PriceVoucher = (vouchers[i].GiaVoucher);
                listVoucher[i].DoiVoucherClicked += this.select_DoiVoucher;
                if (vouchers[i].HinhAnh != "")
                {
                    listVoucher[i].ImageVoucher = handleUrlImage(vouchers[i].HinhAnh);
                }
                flowLayout.Controls.Add(listVoucher[i]);
            }
        }

        public void loadformMyVoucher()
        {
            flowLayout.Controls.Clear();
            MyVoucher[] listMyVoucher = new MyVoucher[myVouchers.Count];
            for (int i = 0; i < myVouchers.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listMyVoucher[i] = new MyVoucher();
                listMyVoucher[i].IdMyVoucher = myVouchers[i].MaMyVoucher;
                listMyVoucher[i].NameMyVoucher = myVouchers[i].TenMyVoucher;
                listMyVoucher[i].PriceMyVoucher = myVouchers[i].GiaMyVoucher;
                listMyVoucher[i].Quantity = myVouchers[i].Quantity;
                //listMyVoucher[i].Click += new System.EventHandler(this.select_MyVoucher);
                listMyVoucher[i].UseVoucherClicked += select_UseMyVoucher;
                listMyVoucher[i].BoVoucherClicked += select_BoMyVoucher;
                if (myVouchers[i].HinhAnh != "")
                {
                    listMyVoucher[i].ImageMyVoucher = handleUrlImage(myVouchers[i].HinhAnh);
                }
                flowLayout.Controls.Add(listMyVoucher[i]);
            }
        }



        //Load product by name


        //add click event for btn in navigation
        //home page
        private void btn_home_Click(object sender, EventArgs e)
        {
            lb_chonDanhMuc.Visible = true;
            lb_danhMucPhu.Visible = true;
            lb_tatCa.Visible = true;
            lb_phoBien.Visible = true;
            pb_muiTen.Visible = true;
            btn_tatCa.Visible = false;
            btn_maCuaToi.Visible = false;
            DiemTichLuy.Visible = false;
            typeOfProduct = "home";
            flowLayout.Controls.Clear();
            loadProductToFlowLayout(list_product);
            //loadFlowLayout("");
            //HomeForm_Load(sender, e);
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
            loadFlowLayout("");
        }

        //fast food page
        private void btn_fast_foods_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DAV";
            loadFlowLayout("");
            Point currentPosition = btn_fast_foods.Location;
            pn_choice.Location = new Point(currentPosition.X + 120, currentPosition.Y + 10);
        }

        //others page
        private void btn_others_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DGD";
            loadFlowLayout("");
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
            ProductOrderItem order = new ProductOrderItem();
            ProductOrderItem temp = findProductItem(obj);
            if (temp != null)
            {
                order = temp;
                order.NumberOfItem += 1;


            } else
            {
                order.NameItemOder = obj.NameProduct;
                order.PriceItemOder = obj.PriceProduct;
                order.NumberOfItem = 1;
                //order.Click += new System.EventHandler(this.select_Product_Cart);
                order.pb_plusClicked += select_PlusProduct_Cart;
                order.pb_minusClicked += select_MinusProduct_Cart;
                orders.Add(order);
                flowLayoutItemOder.Controls.Add(order);
            }
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
            return null;
        }


        void select_MinusProduct_Cart(object sender, EventArgs e)
        {
            ProductOrderItem obj = (ProductOrderItem)sender;
            obj.NumberOfItem = obj.NumberOfItem;
            if (obj.NumberOfItem <= 0)
            {
                flowLayoutItemOder.Controls.Remove(obj);
                orders.Remove(obj);
                //show_product_cart();
            }
            ThanhToan.TongTien -= obj.PriceItemOder;
        }

        void select_PlusProduct_Cart(object sender, EventArgs e)
        {
            ProductOrderItem obj = (ProductOrderItem)sender;
            ThanhToan.TongTien += obj.PriceItemOder;
        }


        //Calculate total money of user's cart
        void calculeteCart()
        {
            int totalMoney = 0;
            foreach (var item in orders)
            {
                totalMoney += item.PriceItemOder * item.NumberOfItem;
            }
            ThanhToan.TongTien = totalMoney;
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

        //Add search function 
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (tb_search.Text == "")
            {
                HomeForm_Load(sender, e);
            }
            else
            {
                String nameOfProduct = tb_search.Text;
                MessageBox.Show(nameOfProduct);
                loadFlowLayout(nameOfProduct);
            }
        }

        private void select_DoiVoucher(object sender, EventArgs e)
        {
            Voucher obj = (Voucher)sender;
            int priceVoucher = obj.PriceVoucher;
            int accumulatedPointsUser = user.AccumulatedPointsUser;
            if (accumulatedPointsUser > priceVoucher)
            {
                MessageBox.Show(obj.IdVoucher.ToString());
                DTO_MyVoucher myVoucher = new DTO_MyVoucher(user.IdUser, obj.IdVoucher);
                BUS_MyVoucher bus_myVoucher = new BUS_MyVoucher();

                MessageBox.Show(myVoucher.MaUser);
                MessageBox.Show(myVoucher.MaMyVoucher.ToString());
                if (user.AccumulatedPointsUser > obj.PriceVoucher)
                {
                    bus_myVoucher.insertMyVoucher(myVoucher);
                    BUS_User bus_user = new BUS_User();
                    user.AccumulatedPointsUser -= obj.PriceVoucher;
                    bus_user.updatePoint(user, user.AccumulatedPointsUser);
                    DiemTichLuy.Point = user.AccumulatedPointsUser;
                    //lb_soDiem.Text = user.AccumulatedPointsUser.ToString();
                }
                else
                {
                    MessageBox.Show("Bạn không có đủ điểm tích lũy");
                }
            }
        }


        private void select_UseMyVoucher(object sender, EventArgs e)
        {
            MyVoucher obj = (MyVoucher)sender;
            if(obj.Quantity > 0) 
            {
                ThanhToan.TienVoucher += obj.PriceMyVoucher;
            }
        }

        private void select_BoMyVoucher(object sender, EventArgs e)
        {
            MyVoucher obj = (MyVoucher)sender;
            ThanhToan.TienVoucher -= obj.PriceMyVoucher;

        }


        private void btn_maCuaToi_Click(object sender, EventArgs e)
        {
            myVouchers.Clear();
            BUS_ListMyVoucher bUS_ListMyVoucher = new BUS_ListMyVoucher();
            bUS_ListMyVoucher.showAllUserVouchers(myVouchers, user.IdUser);
            loadformMyVoucher();
        }

        private void select_Mua(object sender, EventArgs e)
        {

        }
    }
}
