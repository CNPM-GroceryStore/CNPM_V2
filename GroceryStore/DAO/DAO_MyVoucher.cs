using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_MyVoucher
    {
        #region 1. Insert MyVoucher
        public void insertMyVoucher(DTO_MyVoucher myVoucher)
        {
            string statement = "InsertToMyVoucher @numberPhone, @maVoucher";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { myVoucher.IdUser, myVoucher.IdMyVoucher });
        }
        #endregion


        #region 2. Delete MyVoucher
        public void deleteMyVoucher(DTO_MyVoucher myVoucher)
        {
            string statement = "deleteMyVoucher @numberPhone, @MaVoucher, @SoLuong";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { myVoucher.IdUser, myVoucher.IdMyVoucher, myVoucher.QuantityMyVoucher });
        }
        #endregion
    }
}
