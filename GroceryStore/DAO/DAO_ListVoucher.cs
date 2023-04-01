using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ListVoucher
    {
        #region 1. Show all voucher
        public DataTable showAllVouchers()
        {
            string statement = "SELECT TenVoucher, GiaVoucher, HinhAnh FROM Voucher";
            return DataProvider.Instance.ExecuteQuery(statement);
        }
        #endregion

        #region 2. show vouchers by name
        public DataTable getVouchersByName(String name)
        {
            string statement = $"SELECT * FROM Voucher WHERE TenVoucher = @TenVoucher";
            return DataProvider.Instance.ExecuteQuery(statement, new object[] { name });

        }
        #endregion 
    }
}
