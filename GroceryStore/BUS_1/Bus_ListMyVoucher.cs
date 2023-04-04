using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ListMyVoucher
    {

        #region 1. Show all Voucher of User
        public void showAllUserVouchers(List<DTO_MyVoucher> myVouchers, String idUser)
        {
            DAO_ListMyVoucher dAO_listMyVoucher = new DAO_ListMyVoucher();
            foreach (DataRow row in dAO_listMyVoucher.showAllUserVouchers(idUser).Rows)
            {
                DTO_MyVoucher myVoucher = new DTO_MyVoucher(Convert.ToInt32(row[0]), (String)row[1], Convert.ToInt32(row[2]), (String)row[3], Convert.ToInt32(row[4]));
                myVouchers.Add(myVoucher);
            }
        }
        #endregion
    }
}
