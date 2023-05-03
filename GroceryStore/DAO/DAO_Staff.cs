using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_Staff
    {
        #region 1. show all info of staff
        public DataTable showAllStaff()
        {
            string statement = "showAllStaff";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
        }
        #endregion

        #region 2. create account for staff
        public void registerAccount(DTO_Staff staff)
        {
            string statement = "registerAccount @Phone , @Email , @Name , @Address , @Password";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { staff.IdStaff, staff.EmailStaff, staff.NameStaff, staff.AddressStaff, staff.PasswordStaff });
        }
        #endregion

        #region 3. update account for staff
        public void updateAccount(DTO_Staff staff)
        {
            string statement = "updateAccount @Phone , @Email , @Name , @Address , @Password, @numberPhone";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { staff.IdStaff, staff.EmailStaff, staff.NameStaff, staff.AddressStaff, staff.PasswordStaff});
        }
        #endregion

        #region 4. delete account for staff
        public void deleteAccount(DTO_Staff staff)
        {
            string statement = "deleteAccount @numberPhone";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { staff.IdStaff });
        }
        #endregion

        #region 5. Login Account Staff
        public DataTable loginAccountStaff(DTO_Staff staff)
        {
            DataTable dataTable = new DataTable();
            if (checkAccountStaff(staff))
            {
                string statement = "loginAccountStaff @numberPhone";
                dataTable = DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { staff.IdStaff});
            }
            return dataTable;
        }
        #endregion

        #region 6. Check account
        public bool checkAccountStaff(DTO_Staff staff)
        {
            string statement = "checkAccountStaff @numberPhone @password";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] { staff.IdStaff, staff.PasswordStaff }));
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
