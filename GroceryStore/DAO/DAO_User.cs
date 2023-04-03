using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_User
    {
        #region 1. show all info of user
        public DataTable showAllUser()
        {
            string statement = "SELECT SoDienThoai, Email, HoTen, DiaChi, DiemTichLuy FROM NhanVien";
            return DataProvider.Instance.ExecuteQuery(statement);
        }
        #endregion

        #region 2. create account for user
        public void registerAccount(DTO_User user)
        {
            string statement = "INSERT INTO NhanVien (SoDienThoai, Email, HoTen, DiaChi, MatKhau) VALUES ( @Phone , @Email , @Name , @Address , @Password )";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { user.IdUser, user.EmailUser, user.NameUser, user.AddressUser, user.PasswordUser });
        }
        #endregion

        #region 3. update account for user
        public void updateAccount(DTO_User user)
        {
            string statement = "UPDATE NhanVien SET SoDienThoai = @SoDienThoai , Email = @Email , HoTen = @HoTen , DiaChi = @DiaChi , MatKhau = @MatKhau";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { user.IdUser, user.EmailUser, user.NameUser, user.AddressUser, user.PasswordUser});
        }
        #endregion

        #region 4. delete account for user
        public void deleteAccount(DTO_User user)
        {
            string statement = "DELETE FROM NhanVien WHERE SoDienThoai = @SoDienThoai";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { user.IdUser });
        }
        #endregion

        #region 5. Login Account User
        public DataTable loginAccount(DTO_User user)
        {
            DataTable dataTable = new DataTable();
            if (checkAccount(user))
            {
                string statement = "SELECT SoDienThoai, Email, HoTen, DiaChi, DiemTichLuy FROM NhanVien WHERE SoDienThoai = @SoDienThoai";
                dataTable = DataProvider.Instance.ExecuteQuery(statement, new object[] { user.IdUser});
            }
            return dataTable;
        }
        #endregion

        #region 6. Check account exist
        public bool checkAccount(DTO_User user)
        {
            string statement = "SELECT COUNT(SoDienThoai) AS 'Tontai' FROM NhanVien WHERE SoDienThoai LIKE @sdt";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(statement, new object[] { user.IdUser}));
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 7. update point for user
        public void updatePoint(DTO_User user, int point)
        {
            string statement = "update NhanVien Set DiemTichLuy = @DiemTichLuy where SoDienThoai = @SoDienThoai;";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { point, user.IdUser});
        }
        #endregion
    }
}
