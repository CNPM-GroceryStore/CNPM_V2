using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class BUS_Staff
    {
        DAO_Staff dAO_staff = new DAO_Staff();
        #region 1. Create Account Staff
        public void createAccount(DTO_Staff staff)
        { 
            dAO_staff.registerAccount(staff);

        }
        #endregion

        #region 2. Delete Account Staff
        public void deleteAccount(DTO_Staff staff)
        {
            dAO_staff.deleteAccount(staff);
        }
        #endregion

        #region 3. Update Account staff
        public void updateAccount(DTO_Staff staff)
        {
            dAO_staff.updateAccount(staff);
        }
        #endregion

        #region 4. Login Account Staff
        public DTO_Staff loginAccountStaff(DTO_Staff staff)
        {
            foreach(DataRow row in dAO_staff.loginAccountStaff(staff).Rows)
            {
                staff.IdStaff = row[0].ToString();
                staff.EmailStaff = row[1].ToString();
                staff.NameStaff = row[2].ToString();
                staff.AddressStaff = row[3].ToString();
            }
            return staff;
        }
        #endregion

        #region 5. Check Account staff
        public bool checkAccountStaff(DTO_Staff staff)
        {
            return dAO_staff.checkAccountStaff(staff);
        }
        #endregion

        #region 6. Get all staff
        public DataTable getAllStaff()
        {
            return dAO_staff.getAllStaff();
        }
        #endregion

    }

}
