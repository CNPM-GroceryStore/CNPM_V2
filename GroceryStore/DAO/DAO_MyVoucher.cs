using DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
            string statement = "InsertToMyVoucher @soDienThoai, @maVoucher";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { myVoucher.MaUser, myVoucher.MaMyVoucher });
        }
        #endregion


        #region 2. Delete MyVoucher
        public void deleteMyVoucher(DTO_MyVoucher myVoucher)
        {
            string statement = "delete from MyVoucher where SoDienThoai = @SoDienThoai and MaVoucher = @MaVoucher";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { myVoucher.MaUser, myVoucher.MaMyVoucher });
        }
        #endregion
    }
}
