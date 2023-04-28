using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ListProduct
    {
        #region 1. Show all products 
        public DataTable showAllProducts()
        {
            string statement = "usp_ShowAllProducts";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
        }
        #endregion

        #region 2. show products by type
        public DataTable getProductsByType(String type)
        {
            string statement = $"getProductsByType @typeProduct";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { type });
            
        }
        #endregion 

        #region 3. show products by name
        public DataTable getProductsByName(String name)
        {
            string statement = $"getProductsByName @nameProduct";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { name });

        }
        #endregion 
    }
}
