using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.BUS
{
    public class BUS_MyVoucher
    {
        #region 1. Insert MyVoucher
        public bool insertMyVoucher(DTO_MyVoucher myVoucher)
        {
            DAO_MyVoucher dAO_MyVoucher = new DAO_MyVoucher();
            dAO_MyVoucher.insertMyVoucher(myVoucher);
            return true;
        }
        #endregion

        #region 2. Delete MyVoucher
        public DAO_MyVoucher deleteMyVoucher(DTO_MyVoucher myVoucher)
        {
            DAO_MyVoucher dAO_myVoucher = new DAO_MyVoucher();
            dAO_myVoucher.deleteMyVoucher(myVoucher);
            return dAO_myVoucher;
        }
        #endregion
    }
}
