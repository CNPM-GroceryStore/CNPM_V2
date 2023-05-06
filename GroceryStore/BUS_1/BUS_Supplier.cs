using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_1
{
    public class BUS_Supplier
    {
        DAO_Supplier dAO_Supplier = new DAO_Supplier();
        #region
        public DataTable getSupplier()
        {
            return dAO_Supplier.getSupplier();
        }
        #endregion 
    }
}
