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
    public class BUS_User
    {
        #region 1. Create Account User
        public void createAccount(DTO_User user)
        {
            DAO_User dAO_user = new DAO_User(); 
            dAO_user.registerAccount(user);

        }
        #endregion

        #region 2. Delete Account User
        public void deleteAccount(DTO_User user)
        {
            DAO_User dAO_user = new DAO_User();
            dAO_user.deleteAccount(user);
        }
        #endregion

        #region 3. Update Account user
        public void updateAccount(DTO_User user)
        {
            DAO_User dAO_User = new DAO_User();
            dAO_User.updateAccount(user);
        }
        #endregion

        #region 4. Login Account User
        public DTO_User loginAccount(DTO_User user)
        {
            DAO_User dAO_USER = new DAO_User();
            foreach(DataRow row in dAO_USER.loginAccount(user).Rows)
            {
                user.IdUser = row[0].ToString();
                user.EmailUser = row[1].ToString();
                user.NameUser = row[2].ToString();
                user.AddressUser = row[3].ToString();
                user.AccumulatedPointsUser = Convert.ToInt32(row[4]);
            }
            return user;
        }
        #endregion

        #region 5. Check Account user
        public bool checkAccount(DTO_User user)
        {
            DAO_User user2 = new DAO_User();
            return user2.checkAccount(user);
        }
        #endregion
        #region 6. Update point user
        public void updatePoint(DTO_User user, int point)
        {
            DAO_User dAO_User = new DAO_User();
            dAO_User.updatePoint(user.IdUser, point);
        }
        #endregion

        #region
        public DataTable showAllUser()
        {
            DAO_User dAO_User = new DAO_User();
            return dAO_User.showAllUser();
        }
        #endregion
    }

}
