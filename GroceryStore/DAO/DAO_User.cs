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
            string statement = "showAllUser";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
        }
        #endregion

        #region 2. create account for user
        public void registerAccount(DTO_User user)
        {
            string statement = "registerAccount @Phone , @Email , @Name , @Address , @Password";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { user.IdUser, user.EmailUser, user.NameUser, user.AddressUser, user.PasswordUser });
        }
        #endregion

        #region 3. update account for user
        public void updateAccount(DTO_User user)
        {
            string statement = "updateAccount @Phone , @Email , @Name , @Address , @Password, @numberPhone";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { user.IdUser, user.EmailUser, user.NameUser, user.AddressUser, user.PasswordUser});
        }
        #endregion

        #region 4. delete account for user
        public void deleteAccount(DTO_User user)
        {
            string statement = "deleteAccount @numberPhone";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { user.IdUser });
        }
        #endregion

        #region 5. Login Account User
        public DataTable loginAccount(DTO_User user)
        {
            DataTable dataTable = new DataTable();
            if (checkAccount(user))
            {
                string statement = "loginAccount @numberPhone";
                dataTable = DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { user.IdUser});
            }
            return dataTable;
        }
        #endregion

        #region 6. Check account
        public bool checkAccount(DTO_User user)
        {
            string statement = "checkAccount @numberPhone @password";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] { user.IdUser, user.PasswordUser}));
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 7. update point for user
        public void updatePoint(String idUser, int point)
        {
            string statement = "updatePoint @numberPhone, @DiemTichLuy";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { idUser, point });
        }
        #endregion
    }
}
