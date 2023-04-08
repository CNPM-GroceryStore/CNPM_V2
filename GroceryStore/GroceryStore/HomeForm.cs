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
        String typeOfProduct = "home";
        //String nameOfProduct = "";
        String[] list_nameProduct;

        //Create event when form loaded
        private void HomeForm_Load(object sender, EventArgs e)
        {
            HomeLoad(sender, e);
            loadInfoUser(sender, e);
        }

        public void HomeLoad(object sender, EventArgs e)
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
            calculeteCart();
        }



        //Load Info User
        public void loadInfoUser(object sender, EventArgs e)
        {
            lb_nameUser2.Text = user.NameUser;
            show_product_cart();
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
            lb_soDiem.Text = user.AccumulatedPointsUser.ToString();

            Voucher[] listVoucher = new Voucher[vouchers.Count];
            for (int i = 0; i < vouchers.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listVoucher[i] = new Voucher();
                listVoucher[i].IdVoucher = vouchers[i].MaVoucher;
                listVoucher[i].NameVoucher = vouchers[i].TenVoucher;
                listVoucher[i].PriceVoucher = (vouchers[i].GiaVoucher);
                listVoucher[i].Click += new System.EventHandler(this.select_Voucher);
                if (vouchers[i].HinhAnh != "")
                {
                    listVoucher[i].ImageVoucher = handleUrlImage(vouchers[i].HinhAnh);
                }


                //listVoucher[i].Click += new System.EventHandler(this.select_Voucher);
                flowLayout.Controls.Add(listVoucher[i]);
            }
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
                if (bus_listproduct.getProductsByName(list_products, products, nameProduct) == 0)
                {
                    MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                }
            }
        }

        //Load product by name


        //add click event for btn in navigation
        //home page
        private void btn_home_Click(object sender, EventArgs e)
        {
            btn_tatCa.Visible = false;
            btn_maCuaToi.Visible = false;
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
        //Load image throught link
        private Image LoadImageFromStorage(string type, string urlImage)
        {
            string src = $"..\\..\\..\\Resources\\Product\\{type}\\{urlImage}";
            return Image.FromFile(src);
        }

        //function to choose product which is showed in User Interface
        void select_Product(object sender, EventArgs e)
        {
            ProductItem obj = (ProductItem)sender;
            ProductOrderItem order = findProductItem(obj);
            order.NameItemOder = order.NameItemOder;
            order.NumberOfItem += 1;
            BUS_Cart cart = new BUS_Cart();
            if (!cart.checkExistCart(user))
            {
                cart.createCart(user);
            }
            if (order.NumberOfItem == 1)
            {
                DTO_ProductCart productCard = new DTO_ProductCart(order.NameItemOder, order.NameItemOder, order.PriceItemOder, order.NumberOfItem);
                cart.addProductInCart(user, productCard);
            }
            else
            {

                cart.updateProductFromCart(user, checkExistProductInCart(order));
            }
            order.Click += new System.EventHandler(this.select_Product_Cart);
            show_product_cart();
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

        //Check product exist in Cart
        DTO_ProductCart checkExistProductInCart(ProductOrderItem productOrder)
        {
            BUS_Cart bus_cart = new BUS_Cart();
            foreach(DTO_ProductCart productCart in bus_cart.getProducts(user))
            {
                if (productOrder.NameItemOder == productCart.Name)
                {
                    
                    productCart.Quantity = productOrder.NumberOfItem;
                    return productCart;
                }
            }
            return new DTO_ProductCart(productOrder.NameItemOder, productOrder.NameItemOder, productOrder.PriceItemOder, productOrder.NumberOfItem);
        }

        void select_Product_Cart(object sender, EventArgs e)
        {
            ProductOrderItem obj = (ProductOrderItem)sender;
            obj.NumberOfItem = obj.NumberOfItem;
            obj.NameItemOder = obj.NameItemOder;
            BUS_Cart cart = new BUS_Cart();
            if (obj.NumberOfItem <= 0)
            {
                cart.deleteProductFromCart(user, checkExistProductInCart(obj));
                orders.Remove(obj);
            }
            else
            {
                cart.updateProductFromCart(user, checkExistProductInCart(obj));
            }
            show_product_cart();
            calculeteCart();
        }


        //Calculate total money of user's cart
        void calculeteCart()
        {
            BUS_Cart bus_cart = new BUS_Cart();
            double totalMoney = 0;
            foreach (DTO_ProductCart item in bus_cart.getProducts(user))
            {
                totalMoney += item.Price * item.Quantity;
            }
            lb_totalMoney.Text = totalMoney.ToString() + " đ";
            lb_pay.Text = totalMoney.ToString() + " đ";
        }

        //Show product in user's cart
        void show_product_cart()
        {
            flowLayoutItemOder.Controls.Clear();
            orders.Clear();
            BUS_Cart cart = new BUS_Cart();

            foreach (DTO_ProductCart pro in cart.getProducts(user))
            {
                ProductOrderItem productItem = new ProductOrderItem();
                productItem.NameItemOder = pro.Name;
                productItem.PriceItemOder = pro.Price;
                productItem.NumberOfItem = pro.Quantity;
                productItem.Click += new System.EventHandler(this.select_Product_Cart);
                orders.Add(productItem);
            }
            foreach (var item in orders)
            {
                flowLayoutItemOder.Controls.Add(item);
            }
        }

        //Responsive for homepage when change size of form
        private void HomeForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 1234 && this.Height > 892)
            {
                panel2.Size = new Size((int)(0.7 * this.Width), (int)(0.75 * this.Height));
                flowLayout.Size = new Size((int)(0.67 * this.Width), (int)(0.68 * this.Height));
            }
            else
            {
                panel2.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.5 * this.Width), (int)(0.68 * this.Height));
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
                loadFlowLayout(nameOfProduct);
            }
        }

        private void select_Voucher(object sender, EventArgs e)
        {
            Voucher obj = (Voucher)sender;
            int priceVoucher = obj.PriceVoucher;
            int accumulatedPointsUser = user.AccumulatedPointsUser;
            if(accumulatedPointsUser > priceVoucher)
            {
                DTO_MyVoucher myVoucher = new DTO_MyVoucher(user.IdUser, obj.IdVoucher);
                BUS_MyVoucher bus_myVoucher = new BUS_MyVoucher();
                bus_myVoucher.insertMyVoucher(myVoucher);
            }
        }
    }
}
