using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Supplier
    {
        #region
        public DataTable getSupplier()
        {
            string statement = "getSupplier";
            return  DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
        }
        #endregion 
    }
}
