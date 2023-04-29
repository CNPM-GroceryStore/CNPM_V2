using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Voucher
    {
        #region 1. Insert Voucher
        public void insertVoucher(DTO_Voucher voucher)
        {
            string statement = "insertVoucher @TenVoucher, @GiaVoucher, @HinhAnh";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { voucher.TenVoucher, voucher.GiaVoucher, voucher.HinhAnh });
        }
        #endregion


        #region 2. Delete Voucher
        public void deleteVoucher(DTO_Voucher voucher)
        {
            string statement = "deleteVoucher @mavoucher";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { voucher.MaVoucher });
        }
        #endregion


        #region 3. Update Voucher
        public void updateVoucher(DTO_Voucher voucher)
        {
            string statement = "updateVoucher @TenVoucher, @GiaVoucher, @HinhAnh, @mavoucher";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { voucher.MaVoucher, voucher.GiaVoucher, voucher.HinhAnh });
        }
        #endregion

        #region 4. Check exists Voucher

        public bool checkExistsVoucher(DTO_Voucher voucher)
        {
            string statement = "checkExistsVoucher @TenVoucher, @GiaVoucher, @HinhAnh";
            if (DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] { voucher.TenVoucher}) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
