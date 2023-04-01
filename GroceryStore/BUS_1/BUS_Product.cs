﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.BUS
{
    public class BUS_Product
    {
        #region 1. Insert product
        public bool insertProduct(DTO_Product product)
        {
            DAO_Product dAO_Product = new DAO_Product();
            if(!dAO_Product.checkExistsProduct(product))
            {
                dAO_Product.insertProduct(product);
                return true;
            }
            return false;
        }
        #endregion

        #region 2. Delete product
        public DAO_Product deleteProduct(DTO_Product product)
        {
            DAO_Product dAO_product = new DAO_Product();
            dAO_product.deleteProduct(product);
            return dAO_product;
        }
        #endregion

        #region 3. Update product
        public DTO_Product updateProduct(DTO_Product product)
        {
            DAO_Product dAO_product = new DAO_Product();
            dAO_product.updateProduct(product);
            return product;
        }
        #endregion
    }
}
