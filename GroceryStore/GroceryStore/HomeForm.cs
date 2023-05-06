using BUS;
using BUS_1;
using DAO;
using DTO;
using GroceryStore.BUS;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using System.Drawing.Printing;

namespace GroceryStore
{
    public partial class HomeForm : Form
    {
        private DTO_Staff staff;
        private DTO_User user;
        public HomeForm(DTO_Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
        }


        List<ProductOrderItem> orders = new List<ProductOrderItem>();
        List<DTO_Product> list_product = new List<DTO_Product>();
        List<DTO_Voucher> vouchers = new List<DTO_Voucher>();
        List<DTO_MyVoucher> myVouchers = new List<DTO_MyVoucher>();
        List<DTO_MyVoucher> usedMyVouchers = new List<DTO_MyVoucher>();
        String typeOfProduct = "home";
        Guna2GradientTileButton currButton = new Guna2GradientTileButton();
        String[] list_nameProduct;
        int amountReceived = 0;
        int habitualAmount = 0;

        //Create event when form loaded
        private void HomeForm_Load(object sender, EventArgs e)
        {
            HomeLoad(sender, e);
            loadInfoUser(sender, e);
            switchButton(btn_home);
        }

        public void HomeLoad(object sender, EventArgs e)
        {
            String name = staff.NameStaff;
            String[] x = name.Split(' ');
            name = x[x.Length - 2] + " " + x[x.Length - 1];
            lb_nameUser2.Text = name;
            lb_nameUser1.Text = name;
            //gán giá trị cho comboBox
            cbb_payment.SelectedIndex = 0;
            lb_paydate.Text = DateTime.Now.ToString();
            //tạo mảng chứa sản phẩm

            List<DTO_Product> products = new List<DTO_Product>();
            flowLayout.Controls.Clear();

            List<ProductOrderItem> orders = new List<ProductOrderItem>();
            loadVoucher(vouchers);
            loadProduct(list_product);
            ProductItem[] listProduct = new ProductItem[list_product.Count];
            loadProductToFlowLayout(list_product);
            calculeteCart();
            ThanhToan.Mua_Clicked += this.select_Mua;
        }

        //Switch button
        private void switchButton(Guna2GradientTileButton nextButton)
        {
            currButton.FillColor = Color.White;
            currButton.FillColor2 = Color.White;
            currButton = nextButton;
            currButton.FillColor = ColorTranslator.FromHtml("#F80909");
            currButton.FillColor2 = ColorTranslator.FromHtml("#F80909");
        }

        //Load Info User
        public void loadInfoUser(object sender, EventArgs e)
        {
            lb_nameUser2.Text = staff.NameStaff;
            show_product_cart();
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
                listProduct[i].IdProduct = products[i].IdProduct;
                listProduct[i].NameProduct = products[i].NameProduct;
                listProduct[i].PriceProduct = (products[i].PriceProduct);

                listProduct[i].ImageProduct = LoadImageFromStorage(products[i].TypeProduct, products[i].ImageProduct);

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
            lbl_username.Visible = true;
            lbl_username.Text = user.NameUser;
            DiemTichLuy.Point = user.AccumulatedPointsUser;

            Voucher[] listVoucher = new Voucher[vouchers.Count];
            for (int i = 0; i < vouchers.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listVoucher[i] = new Voucher();
                listVoucher[i].IdVoucher = vouchers[i].IdVoucher;
                listVoucher[i].NameVoucher = vouchers[i].NameVoucher;
                listVoucher[i].PriceVoucher = (vouchers[i].PriceVoucher);
                listVoucher[i].DoiVoucherClicked += this.select_DoiVoucher;
                if (vouchers[i].ImageVoucher != "")
                {
                    listVoucher[i].ImageVoucher = handleUrlImage(vouchers[i].ImageVoucher);
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
                listMyVoucher[i].IdMyVoucher = myVouchers[i].IdMyVoucher;
                listMyVoucher[i].NameMyVoucher = myVouchers[i].NameMyVoucher;
                listMyVoucher[i].PriceMyVoucher = myVouchers[i].PriceMyVoucher;
                listMyVoucher[i].Quantity = myVouchers[i].QuantityMyVoucher;
                //listMyVoucher[i].Click += new System.EventHandler(this.select_MyVoucher);
                listMyVoucher[i].UseVoucherClicked += select_UseMyVoucher;
                listMyVoucher[i].BoVoucherClicked += select_BoMyVoucher;
                if (myVouchers[i].ImageMyVoucher != "")
                {
                    listMyVoucher[i].ImageMyVoucher = handleUrlImage(myVouchers[i].ImageMyVoucher);
                }
                flowLayout.Controls.Add(listMyVoucher[i]);
            }
        }

        //Go to admin form
        private void btn_settings_Click(object sender, EventArgs e)
        {
            Form adminForm = new AdminForm();
            adminForm.Show();
            this.Hide();
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
            lbl_username.Visible = false;
            btn_voucher.Visible = false;
            DiemTichLuy.Visible = false;
            typeOfProduct = "home";
            flowLayout.Controls.Clear();
            loadProductToFlowLayout(list_product);
            //loadFlowLayout("");
            //HomeForm_Load(sender, e);
            Point currentPosition = btn_home.Location;
            pn_choice.Location = new Point(currentPosition.X + 130, currentPosition.Y + 10);
            pn_choice.BringToFront();
            switchButton(btn_home);
        }

        //drink page
        private void btn_drinks_Click(object sender, EventArgs e)
        {
            Point currentPosition = btn_drinks.Location;
            pn_choice.Location = new Point(255, 255);
            pn_choice.BringToFront();
            typeOfProduct = "DU";
            loadFlowLayout("");
            switchButton(btn_drinks);
        }

        //fast food page
        private void btn_fast_foods_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DAV";
            loadFlowLayout("");
            Point currentPosition = btn_fast_foods.Location;
            pn_choice.Location = new Point(currentPosition.X + 120, currentPosition.Y + 10);
            switchButton(btn_fast_foods);
        }

        //others page
        private void btn_others_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DGD";
            loadFlowLayout("");
            Point currentPosition = btn_others.Location;
            pn_choice.Location = new Point(currentPosition.X + 120, currentPosition.Y + 10);
            switchButton(btn_others);
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
            if (File.Exists(src)) // kiểm tra xem file có tồn tại không
            {
                return Image.FromFile(src);
            }
            return null;
        }

        //function to choose product which is showed in User Interface
        void select_Product(object sender, EventArgs e)
        {
            ProductItem obj = (ProductItem)sender;
            ProductOrderItem order = findProductItem(obj);
            order.NumberOfItem += 1;
            BUS_Cart cart = new BUS_Cart();
            if (cart.checkExistCart(staff) == false)
            {
                cart.createCart(staff);
            }
            if (order.NumberOfItem == 1)
            {
                DTO_ProductCart productCard = new DTO_ProductCart(order.IdItemOder, order.NameItemOder, order.PriceItemOder, order.NumberOfItem);
                if (isExistsInCart(order))
                {
                    BUS_Product currentProduct = new BUS_Product();
                    if (currentProduct.checkAmount(order.NumberOfItem, order.IdItemOder))
                    {
                        cart.updateProductFromCart(staff, checkExistProductInCart(order));
                        BUS_Product product = new BUS_Product();
                        product.updateAmount(new DTO_Product(order.IdItemOder), -1);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng hiện tại không đủ!");
                    }
                }
                else
                {
                    BUS_Product product = new BUS_Product();
                    cart.addProductInCart(staff, productCard);
                    product.updateAmount(new DTO_Product(order.IdItemOder), -1);
                }
            }
            else
            {
                BUS_Product currentProduct = new BUS_Product();
                if (currentProduct.checkAmount(order.NumberOfItem, order.IdItemOder))
                {
                    cart.updateProductFromCart(staff, checkExistProductInCart(order));
                    BUS_Product product = new BUS_Product();
                    product.updateAmount(new DTO_Product(order.IdItemOder), -1);
                }
                else
                {
                    MessageBox.Show("Số lượng hiện tại không đủ!");
                }
            }
            //order.Click += new System.EventHandler(this.select_Product_Cart);
            show_product_cart();
            calculeteCart();
        }

        ProductOrderItem findProductItem(ProductItem obj)
        {
            foreach (ProductOrderItem item in orders)
            {
                if (item.IdItemOder == obj.IdProduct)
                {
                    return item;
                }
            }
            ProductOrderItem order = new ProductOrderItem();
            order.IdItemOder = obj.IdProduct;
            order.NameItemOder = obj.NameProduct;
            order.PriceItemOder = obj.PriceProduct;
            order.NumberOfItem = 0;
            return order;
        }

        //Check product exist in Cart
        DTO_ProductCart checkExistProductInCart(ProductOrderItem productOrder)
        {
            BUS_Cart bus_cart = new BUS_Cart();
            foreach (DTO_ProductCart productCart in bus_cart.getProducts(staff))
            {
                if (productOrder.IdItemOder == productCart.ID)
                {
                    productCart.Quantity = productOrder.NumberOfItem;
                    return productCart;
                }
            }
            return new DTO_ProductCart(productOrder.IdItemOder, productOrder.NameItemOder, productOrder.PriceItemOder, productOrder.NumberOfItem);
        }

        //Check product is in cart 
        private bool isExistsInCart(ProductOrderItem productOrder)
        {
            BUS_Cart bus_cart = new BUS_Cart();
            foreach (DTO_ProductCart productCart in bus_cart.getProducts(staff))
            {
                if (productOrder.IdItemOder == productCart.ID)
                {
                    return true;
                }
            }
            return false;
        }

        void select_Product_Cart(object sender, EventArgs e)
        {
            ProductOrderItem obj = (ProductOrderItem)sender;
            BUS_Cart cart = new BUS_Cart();
            if (obj.NumberOfItem <= 0)
            {
                flowLayoutItemOder.Controls.Remove(obj);
                cart.deleteProductFromCart(staff, checkExistProductInCart(obj));
                orders.Remove(obj);
            }
            else
            {
                cart.updateProductFromCart(staff, checkExistProductInCart(obj));
                BUS_Product product = new BUS_Product();
                product.updateAmount(new DTO_Product(obj.IdItemOder), 1);
            }
            show_product_cart();
            calculeteCart();
        }


        //Calculate total money of staff's cart
        void calculeteCart()
        {
            BUS_Cart bus_cart = new BUS_Cart();
            int totalMoney = 0;
            foreach (DTO_ProductCart item in bus_cart.getProducts(staff))
            {
                totalMoney += item.Price * item.Quantity;
            }
            ThanhToan.TongTien = totalMoney;
        }

        //Show product in staff's cart
        void show_product_cart()
        {
            flowLayoutItemOder.Controls.Clear();
            orders.Clear();
            BUS_Cart cart = new BUS_Cart();

            foreach (DTO_ProductCart pro in cart.getProducts(staff))
            {
                ProductOrderItem productItem = new ProductOrderItem();
                productItem.IdItemOder = pro.ID;
                productItem.NameItemOder = pro.Name;
                productItem.PriceItemOder = pro.Price;
                productItem.NumberOfItem = pro.Quantity;
                //productItem.Click += new System.EventHandler(this.select_Product_Cart);
                productItem.pb_minusClicked += this.select_Product_Cart;
                productItem.pb_plusClicked += this.select_Product_Cart;
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
                flowpanel_order_history.Size = new Size((int)(0.3 * this.Width), (int)(0.64 * this.Height));
                //flowLayoutItemOder.Size = new Size((int)(0.3 * this.Width), (int)(0.32 * this.Height));
            }
            else
            {
                panel2.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.5 * this.Width), (int)(0.68 * this.Height));
                flowpanel_order_history.Size = new Size((int)(0.45 * this.Width), (int)(0.57 * this.Height));
            }
        }

        private void flowLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_tatCa_Click(object sender, EventArgs e)
        {
            loadformVoucher();
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

        // click doi voucher
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

                MessageBox.Show(myVoucher.IdUser);
                MessageBox.Show(myVoucher.IdMyVoucher.ToString());
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

        //click use my voucher
        private void select_UseMyVoucher(object sender, EventArgs e)
        {
            MyVoucher obj = (MyVoucher)sender;
            if (obj.Quantity > 0)
            {
                DTO_MyVoucher myVoucher = myVouchers.Find(mv => mv.IdMyVoucher == obj.IdMyVoucher);
                myVoucher.QuantityMyVoucher -= 1;
                DTO_MyVoucher usedMyVoucher = usedMyVouchers.Find(mv => mv.IdMyVoucher == obj.IdMyVoucher);
                if (usedMyVoucher == null)
                {
                    usedMyVouchers.Add(new DTO_MyVoucher(user.IdUser, myVoucher.IdMyVoucher, myVoucher.PriceMyVoucher, 1));
                }
                else
                {
                    usedMyVoucher.QuantityMyVoucher += 1;
                }
                ThanhToan.TienVoucher += obj.PriceMyVoucher;
            }
        }

        //click bo MyVoucher
        private void select_BoMyVoucher(object sender, EventArgs e)
        {
            MyVoucher obj = (MyVoucher)sender;
            DTO_MyVoucher myVoucher = myVouchers.Find(mv => mv.IdMyVoucher == obj.IdMyVoucher);
            myVoucher.QuantityMyVoucher += 1;
            DTO_MyVoucher usedMyVoucher = usedMyVouchers.Find(mv => mv.IdMyVoucher == obj.IdMyVoucher);
            usedMyVoucher.QuantityMyVoucher -= 1;
            ThanhToan.TienVoucher -= obj.PriceMyVoucher;

        }


        // Click ma cua toi
        private void btn_maCuaToi_Click(object sender, EventArgs e)
        {
            myVouchers.Clear();
            ThanhToan.TienVoucher = 0;
            BUS_ListMyVoucher bUS_ListMyVoucher = new BUS_ListMyVoucher();
            bUS_ListMyVoucher.showAllUserVouchers(myVouchers, user.IdUser);
            loadformMyVoucher();
        }

        private void ShowLoginDialog()
        {
            var inputForm = new Form();
            inputForm.Size = new Size(500, 200);
            inputForm.Text = "Nhập thông tin";
            inputForm.StartPosition = FormStartPosition.CenterScreen;

            var phoneLabel = new Label() { Left = 50, Top = 20, Text = "Số điện thoại:" };
            var phoneTextBox = new TextBox() { Left = 150, Top = 20, Width = 200 };
            var passwordLabel = new Label() { Left = 50, Top = 50, Text = "Mật khẩu:" };
            var passwordTextBox = new TextBox() { Left = 150, Top = 50, Width = 200 };

            var okButton = new Button() { Text = "OK", Left = 150, Width = 100, Top = 80, Height = 35 };
            okButton.Click += (sender, e) => { inputForm.DialogResult = DialogResult.OK; };
            var cancelButton = new Button() { Text = "Cancel", Left = 260, Width = 100, Top = 80, Height = 35 };
            cancelButton.Click += (sender, e) => { inputForm.DialogResult = DialogResult.Cancel; };

            inputForm.Controls.Add(phoneLabel);
            inputForm.Controls.Add(phoneTextBox);
            inputForm.Controls.Add(passwordLabel);
            inputForm.Controls.Add(passwordTextBox);
            inputForm.Controls.Add(okButton);
            inputForm.Controls.Add(cancelButton);

            var result = inputForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show(phoneTextBox.Text);
                user = new DTO_User(phoneTextBox.Text, passwordTextBox.Text);
                BUS_User bUS_User = new BUS_User();
                if (bUS_User.checkAccount(user))
                {
                    bUS_User.loginAccount(user);
                    MessageBox.Show("Đăng nhập thành công");
                    btn_voucher.Visible = true;
                    btn_voucher.PerformClick();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu, vui lòng nhập lại!");
                    //ShowLoginDialog();
                }

            }
        }

        private int ShowLoginDialogInputMoney()
        {
            var inputForm = new Form();
            inputForm.Size = new Size(400, 150);
            inputForm.Text = "Nhập số tiền đã nhận";
            inputForm.StartPosition = FormStartPosition.CenterScreen;

            var inputMoneyLable = new Label() { Left = 260, Top = 22, Text = "VNĐ" };
            var inputMoney = new TextBox() { Left = 50, Top = 20, Width = 200 };

            var okButton = new Button() { Text = "OK", Left = 50, Width = 100, Top = 50, Height = 35 };
            okButton.Click += (sender, e) => { inputForm.DialogResult = DialogResult.OK; };
            var cancelButton = new Button() { Text = "Cancel", Left = 160, Width = 100, Top = 50, Height = 35 };
            cancelButton.Click += (sender, e) => { inputForm.DialogResult = DialogResult.Cancel; };

            inputForm.Controls.Add(inputMoneyLable);
            inputForm.Controls.Add(inputMoney);
            inputForm.Controls.Add(okButton);
            inputForm.Controls.Add(cancelButton);

            var result = inputForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                return Convert.ToInt32(inputMoney.Text);
            }
            return 0;
        }
        // Phương thức cắt chuỗi cho tên sản phẩm
        private string[] SplitString(string str, Font font, float maxWidth, Graphics g)
        {
            string[] words = str.Split(' ');
            List<string> lines = new List<string>();
            string currentLine = "";
            for (int i = 0; i < words.Length; i++)
            {
                SizeF size = g.MeasureString(currentLine + words[i], font);
                if (size.Width > maxWidth) // Nếu độ dài dòng hiện tại vượt quá chiều rộng tối đa, tạo một dòng mới
                {
                    lines.Add(currentLine);
                    currentLine = words[i] + " ";
                }
                else
                {
                    currentLine += words[i] + " ";
                }
            }
            if (currentLine != "") lines.Add(currentLine); // Thêm dòng cuối cùng
            return lines.ToArray();
        }
        //In hóa đơn
        private void printBill(object sender, PrintPageEventArgs e)
        {
            // Vẽ thông tin hóa đơn lên trang in
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 12);
            Font boldFont = new Font("Arial", 12, FontStyle.Bold);
            Brush brush = Brushes.Black;
            int startX = 10;
            int startY = 10;
            int offset = 40;
            int sumNumber = 0;
            int sumMoney = 0;
            int addOffset = 0;

            g.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 18), brush, startX + 200, startY);

            // Vẽ thông tin khách hàng
            if(user != null)
            {
                g.DrawString("Khách hàng: " + user.NameUser, font, brush, startX, startY + offset);
                offset += 20;
            }

            // Vẽ thông tin sản phẩm
            g.DrawString("Tên sản phẩm", boldFont, brush, startX + 50, startY + offset);
            g.DrawString("Số lượng" , boldFont, brush, startX + 300, startY + offset);
            g.DrawString("Giá", boldFont, brush, startX + 450, startY + offset);
            g.DrawString("Thành tiền", boldFont, brush, startX + 550, startY + offset);
            offset += 20;
            foreach (ProductOrderItem order in orders)
            {
                string name = order.NameItemOder;
                SizeF size = g.MeasureString(name, font);
                if (size.Width > 300) // Nếu tên sản phẩm dài hơn kích thước trang in, tách thành nhiều dòng
                {
                    string[] nameLines = SplitString(name, font, 300, g);
                    for (int i = 0; i < nameLines.Length; i++)
                    {
                        g.DrawString(nameLines[i], font, brush, startX, startY + offset);
                        addOffset += 20;
                        offset += 20;
                    }
                    offset -= addOffset;
                }
                else // Nếu tên sản phẩm ngắn, in trên một dòng
                {
                    g.DrawString(name, font, brush, startX, startY + offset);
                }

                g.DrawString(order.NumberOfItem.ToString(), font, brush, startX + 300, startY + offset);
                g.DrawString(order.PriceItemOder.ToString(), font, brush, startX + 450, startY + offset);
                g.DrawString((order.PriceItemOder * order.NumberOfItem).ToString(), font, brush, startX + 550, startY + offset);
                offset += 20 + addOffset;
                addOffset = 0;
                sumNumber += order.NumberOfItem;
                sumMoney += order.PriceItemOder * order.NumberOfItem;
            }

            // Tính tổng tiền
            int tongTien = ThanhToan.TienThanhToan;

            // Vẽ thông tin tổng tiền
            g.DrawString("Tổng số/Tổng cộng:", boldFont, brush, startX, startY + offset);
            g.DrawString(sumNumber.ToString(), font, brush, startX + 300, startY + offset);
            g.DrawString(sumMoney.ToString(), font, brush, startX + 550, startY + offset);
            offset += 30;
            // Tiền nhận
            g.DrawString("Khách trả", boldFont, brush, startX, startY + offset);
            g.DrawString(amountReceived.ToString(), font, brush, startX + 550, startY + offset);
            offset += 30;
            //Tiền thói
            g.DrawString("Trả lại", boldFont, brush, startX, startY + offset);
            g.DrawString(habitualAmount.ToString(), font, brush, startX + 550, startY + offset);
            offset += 30;
            // Vẽ thông tin ngày in
            g.DrawString("Ngày in: " + DateTime.Now.ToString(), font, brush, startX, startY + offset);
            offset += 50;
            //Cảm ơn quý khách
            g.DrawString("Xin cảm ơn quý khách!", boldFont, brush, startX, startY + offset);

        }


        // click mua
        private void select_Mua(object sender, EventArgs e)
        {
            DialogResult dialogUser = new DialogResult();
            if (user == null)
            {
                dialogUser = MessageBox.Show($"Bạn có muốn dùng tài khoản thành viên?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialogUser == DialogResult.Yes)
                {
                    ShowLoginDialog();
                    return;
                }
            }

            //MessageBox.Show($"Khách hàng đã thanh toán {ThanhToan.TienThanhToan}");
            ////DialogResult dialog = new DialogResult();

            BUS_OrderHistory order = new BUS_OrderHistory();
            BUS_Cart cart = new BUS_Cart();
            BUS_User bUS_User = new BUS_User();
            if (user != null)
            {
                user.AccumulatedPointsUser += ThanhToan.DiemTichLuy;
                bUS_User.updatePoint(user, user.AccumulatedPointsUser);
            }
            int price = ThanhToan.TienThanhToan;
            int amount = cart.getProducts(staff).Count;
            string paymethod = cbb_payment.Text;
            string paydate = lb_paydate.Text;
            string status = "";
            if (amount > 0 && paymethod != "Thanh toán")
            {
                DialogResult dialog = MessageBox.Show($"Khách hàng đã thanh toán?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    if (paymethod == "Tiền mặt")
                    {
                        amountReceived = ShowLoginDialogInputMoney();
                        habitualAmount = amountReceived - ThanhToan.TienThanhToan;
                        MessageBox.Show("Số tiền thói: " + habitualAmount, "Thông báo");
                    }
                    status = "Hoàn thành";
                    if (user != null)
                    {
                        BUS_MyVoucher bUS_MyVoucher = new BUS_MyVoucher();
                        usedMyVouchers.ForEach(umv =>
                        {
                            bUS_MyVoucher.deleteMyVoucher(umv);
                        });
                    }


                    // In hóa đơn
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(printBill);
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ppd.Document = pd;
                    ppd.ShowDialog();

                    // Reset dữ liệu mua hàng
                    myVouchers.Clear();
                    usedMyVouchers.Clear();
                    cart.deleteCart(staff);
                    flowLayoutItemOder.Controls.Clear();
                    ThanhToan.clear();
                    user = null;
                }
                else
                {
                    status = "Chưa hoàn thành";
                }

                DTO_OrderHistory orderHistoryItem = new DTO_OrderHistory(price, amount, paymethod, status, paydate);
                order.insertOrderHistory(staff, orderHistoryItem);
                btn_home.PerformClick();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào được chọn hoặc chưa chọn phương thức thanh toán");
            }

        }

        //CLick Order History
        private void click_orderHistory(object sender, EventArgs e)
        {
            flowpanel_order_history.Controls.Clear();
            BUS_OrderHistory orderHistory = new BUS_OrderHistory();
            foreach (DTO_OrderHistory dTO_OrderHistory in orderHistory.showALl(staff))
            {
                string id = dTO_OrderHistory.id;
                int price = dTO_OrderHistory.price;
                int amount = dTO_OrderHistory.amount;
                string paymethod = dTO_OrderHistory.paymethod;
                string paydate = dTO_OrderHistory.paydate;
                string status = dTO_OrderHistory.status;
                OrderHistoryItem orderHistoryItem = new OrderHistoryItem();
                orderHistoryItem.ID = id;
                orderHistoryItem.Price = price;
                orderHistoryItem.Amount = amount;
                orderHistoryItem.Paymethod = paymethod;
                orderHistoryItem.Paydate = paydate;
                orderHistoryItem.Status = status;
                flowpanel_order_history.Controls.Add(orderHistoryItem);

            }
        }

        // click gio hang
        private void click_order(object sender, EventArgs e)
        {
            flowpanel_order_history.Visible = false;
        }

        // click lich su gio hang
        private void showOrderHistory(object sender, EventArgs e)
        {
            flowpanel_order_history.Visible = true;
            click_orderHistory(sender, e);
        }

        private void lbl_username_Click(object sender, EventArgs e)
        {
            DialogResult dialogSignOut = MessageBox.Show($"Bạn có muốn đăng xuất tài khoản khách hàng?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogSignOut == DialogResult.Yes)
            {
                user = null;
                lbl_username.Text = "Username";
                lbl_username.Visible = false;
            }
        }
    }
}
////////////////////////////////////////
