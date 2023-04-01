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
            string statement = "INSERT INTO Voucher (TenVoucher, GiaVoucher, HinhAnh) VALUES ( @TenVoucher , @GiaVoucher , @HinhAnh)";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { voucher.TenVoucher, voucher.GiaVoucher, voucher.HinhAnh });
        }
        #endregion


        #region 2. Delete Voucher
        public void deleteVoucher(DTO_Voucher voucher)
        {
            string statement = "DELETE FROM Voucher WHERE MaVoucher = @mavoucher";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { voucher.MaVoucher });
        }
        #endregion


        #region 3. Update Voucher
        public void updateVoucher(DTO_Voucher voucher)
        {
            string statement = "UPDATE Voucher SET TenVoucher = @TenVoucher , GiaVoucher = @GiaVoucher , HinhAnh = @HinhAnh";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { voucher.MaVoucher, voucher.GiaVoucher, voucher.HinhAnh });
        }
        #endregion

        #region 4. Check exists Voucher

        public bool checkExistsVoucher(DTO_Voucher voucher)
        {
            string statement = "SELECT TenVoucher , GiaVoucher , HinhAnh FROM Voucher WHERE TenVoucher = @TenVoucher , GiaVoucher = @GiaVoucher , HinhAnh = @HinhAnh";
            if (DataProvider.Instance.ExecuteNonQuery(statement, new object[] { voucher.TenVoucher}) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
