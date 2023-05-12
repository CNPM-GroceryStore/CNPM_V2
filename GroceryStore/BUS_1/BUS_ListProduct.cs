using DAO;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ListProduct
    {
        #region 3. Show all products
        public void showAllProduct(List<DTO_Product> products)
        {
            DAO_ListProduct dAO_listProduct = new DAO_ListProduct();
            products.Clear();
            foreach (DataRow row in dAO_listProduct.showAllProducts().Rows)
            {
                DTO_Product product = new DTO_Product(Convert.ToInt32(row[0]), (String)row[1], Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), (String)row[4], (String)row[5], (string)row[6], row[7].ToString());
                products.Add(product);
            }
        }
        #endregion

        #region 4. get products by type
        public int getProductsByType(List<DTO_Product> list_products, List<DTO_Product> products, String type)
        {
            type = type.ToLower();
            type = Regex.Replace(type, @"\s+", " ");
            foreach (DTO_Product product in list_products)
            {
                String loaiSP = Regex.Replace(product.TypeProduct, @"\s+", " ");
                loaiSP = loaiSP.ToLower();
                if (loaiSP == type)
                {
                    products.Add(product);
                }
            }
            return products.Count;
        }
        #endregion

        #region 5. Get products by name
        public int getProductsByName(List<DTO_Product> list_products, List<DTO_Product> products, String name)
        {
            name = this.convertVietnamese(name);
            String[] split_input = name.Split(' ');
            foreach (DTO_Product product in list_products)
            {
                String namePro = this.convertVietnamese(product.NameProduct);
                if (namePro == name)
                {
                    products.Add(product);
                }
                else
                {
                    foreach(String input_name in split_input)
                    {
                        if (namePro.Contains(input_name))
                        {
                            products.Add(product);
                            break;
                        }
                    }
                }

            }
            return products.Count;
        }
        #endregion


        #region 6.Show products by type
        public void showProductByType(List<DTO_Product> products, String type)
        {
            DAO_ListProduct dAO_listProduct = new DAO_ListProduct();
            foreach (DataRow row in dAO_listProduct.getProductsByType(type).Rows)
            {
                DTO_Product product = new DTO_Product((String)row[0], Convert.ToInt32(row[1]), (String)row[2], (String)row[3]);
                products.Add(product);
            }
        }
        #endregion

        #region 7.Show products by name
        public void showProductByName(List<DTO_Product> products, String name)
        {
            DAO_ListProduct dAO_listProduct = new DAO_ListProduct();
            foreach (DataRow row in dAO_listProduct.getProductsByName(name).Rows)
            {
                DTO_Product product = new DTO_Product((String)row[0], Convert.ToInt32(row[1]), (String)row[2], (String)row[3]);
                products.Add(product);
            }
        }
        #endregion

        #region 8. get products by type and name
        public int getProductsByTypeAndName(List<DTO_Product> list_products, List<DTO_Product> products, String type, String name)
        {
            type = type.ToLower();
            type = Regex.Replace(type, @"\s+", " ");
            name = name.ToLower();
            name = Regex.Replace(name, @"\s+", " ");
            String[] split_input = name.Split(' ');
            foreach (DTO_Product product in list_products)
            {
                String loaiSP = Regex.Replace(product.TypeProduct, @"\s+", " ");
                loaiSP = loaiSP.ToLower();
                if (loaiSP == type)
                {
                    String namePro = Regex.Replace(product.NameProduct, @"\s+", " ");
                    namePro = namePro.ToLower();
                    if (namePro == name)
                    {
                        products.Add(product);
                    }
                    else
                    {
                        foreach (String input_name in split_input)
                        {
                            if (namePro.Contains(input_name))
                            {
                                products.Add(product);
                                break;
                            }
                        }
                    }

                }
            }
            return products.Count;
        }
        #endregion

        #region 9. usp_ShowAllProductsAdmin
        public void showAllProductAdmin(List<DTO_Product> products)
        {
            DAO_ListProduct dAO_listProduct = new DAO_ListProduct();
            products.Clear();
            foreach (DataRow row in dAO_listProduct.showAllProductAdmin().Rows)
            {
                DTO_Product product = new DTO_Product(Convert.ToInt32(row[0]), (String)row[1], Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), (String)row[4], (String)row[5], (string)row[6], row[7].ToString());
                products.Add(product);
            }
        }
        #endregion

        #region 10. Show product in manage page
        public DataTable showProductsManagePage()
        {
            DAO_ListProduct dAO_listProduct = new DAO_ListProduct();
            return dAO_listProduct.showAllProductAdmin();
        }
        #endregion

        #region 11. convert Vietnamese
        public string convertVietnamese(string str)
        {
            str = str.ToLower();
            str = Regex.Replace(str, @"\s+", " ");
            str = Regex.Replace(str, "[áàảãạăắằẳẵặâấầẩẫậ]", "a");
            str = Regex.Replace(str, "[đ]", "d");
            str = Regex.Replace(str, "[éèẻẽẹêếềểễệ]", "e");
            str = Regex.Replace(str, "[íìỉĩị]", "i");
            str = Regex.Replace(str, "[óòỏõọôốồổỗộơớờởỡợ]", "o");
            str = Regex.Replace(str, "[úùủũụưứừửữự]", "u");
            str = Regex.Replace(str, "[ýỳỷỹỵ]", "y");
            return str;
        }
        #endregion
    }
}
