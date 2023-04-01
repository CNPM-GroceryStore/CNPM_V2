using DAO;
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
        #region 1. Insert products
        public void insertProduct(DTO_ListProduct products)
        {
            foreach (DTO_Product product in products.GetAll())
            {
                DAO_Product dAO_Product = new DAO_Product();
                dAO_Product.insertProduct(product);
            }
        }
        #endregion


        #region 2.Delete products
        public void deleteProducts(DTO_ListProduct products)
        {
            foreach (DTO_Product product in products.GetAll())
            {
                DAO_Product dAO_Product = new DAO_Product();
                dAO_Product.deleteProduct(product);
            }
        }
        #endregion

        #region 3. Show all products
        public void showAllProduct(List<DTO_Product> products)
        {
            DAO_ListProduct dAO_listProduct = new DAO_ListProduct();
            foreach (DataRow row in dAO_listProduct.showAllProducts().Rows)
            {
                DTO_Product product = new DTO_Product((String)row[0], Convert.ToInt32(row[1]), (String)row[2], (String)row[3]);
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
                String loaiSP = Regex.Replace(product.LoaiSP, @"\s+", " ");
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
            name = name.ToLower();
            name = Regex.Replace(name, @"\s+", " ");
            String[] split_input = name.Split(' ');
            foreach (DTO_Product product in list_products)
            {
                String namePro = Regex.Replace(product.TenSP, @"\s+", " ");
                namePro = namePro.ToLower();
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

        #region 7.Show products by type
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
    }
}
