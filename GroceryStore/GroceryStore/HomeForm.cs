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
        String typeOfProduct = "";
        String nameOfProduct = "";

        //Create event when form loaded
        private void HomeForm_Load(object sender, EventArgs e)
        {
            //Load homepage 
            HomeLoad(sender, e);
            //Load info of user
            loadInfoUser(sender, e);
        }

        //Load home
        public void HomeLoad(object sender, EventArgs e)
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

        //Load products to show in homepage
        public void loadProduct(List<DTO_Product> products)
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            bus_listproduct.showAllProduct(products);
        }

        //Load FlowLayout when switch selector
        public void loadFlowLayout(String attribute)
        {
            List<DTO_Product> products = new List<DTO_Product>();
            flowLayout.Controls.Clear();
            loadProduct(list_product, products, attribute);
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

        //Load product by type
        public void loadProduct(List<DTO_Product> list_products, List<DTO_Product> products, String attribute)
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            if (typeOfProduct != "")
            {
                if (bus_listproduct.getProductsByType(list_products, products, attribute) == 0)
                {
                    MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                }
            }
            else if (nameOfProduct != "")
            {
                if (bus_listproduct.getProductsByName(list_products, products, attribute) == 0)
                {
                    MessageBox.Show("Xin lỗi, không tìm thấy sản phẩm của bạn!");
                }
            }
        }

        //Load Info User
        public void loadInfoUser(object sender, EventArgs e)
        {
            lb_name1.Text = user.NameUser;
            show_product_cart();
        }

        //add click event for btn in navigation
        //home page
        private void btn_home_Click(object sender, EventArgs e)
        {
            typeOfProduct = "";
            HomeForm_Load(sender, e);
        }

        //drink page
        private void btn_drinks_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DU";
            loadFlowLayout(typeOfProduct);
        }

        //fast food page
        private void btn_fast_foods_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DAV";
            loadFlowLayout(typeOfProduct);
        }

        //others page
        private void btn_others_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DGD";
            loadFlowLayout(typeOfProduct);
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
            flowLayoutItemOder.Controls.Clear();
            ProductOrderItem order = new ProductOrderItem();
            order.NameItemOder = obj.NameProduct;
            order.PriceItemOder = obj.PriceProduct;
            order.NumberOfItem = 1;
            order.Click += new System.EventHandler(this.select_Product_Cart);
            orders.Add(order);
            show_product_cart();
            calculeteCart();
        }

        //interact with products in cart
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
            BUS_Cart cart = new BUS_Cart();

            foreach (DTO_ProductCard pro in cart.getProducts(user))
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
            if (this.Width > 1440)
            {
                panel2.Size = new Size((int)(0.7 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.7 * this.Width), (int)(0.78 * this.Height));
            }
            else
            {
                panel2.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.49 * this.Width), (int)(0.78 * this.Height));
            }
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
                nameOfProduct = tb_search.Text;
                loadFlowLayout(nameOfProduct);
            }
        }

    }
}
