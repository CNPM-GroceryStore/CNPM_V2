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
    public class BUS_ListVoucher
    {
        #region 1. Insert Voucher
        public void insertVoucher(DTO_ListVoucher vouchers)
        {
            foreach (DTO_Voucher voucher in vouchers.GetAll())
            {
                DAO_Voucher dAO_Voucher = new DAO_Voucher();
                dAO_Voucher.insertVoucher(voucher);
            }
        }
        #endregion


        #region 2.Delete Voucher
        public void deleteVoucher(DTO_ListVoucher vouchers)
        {
            foreach (DTO_Voucher voucher in vouchers.GetAll())
            {
                DAO_Voucher dAO_Voucher = new DAO_Voucher();
                dAO_Voucher.deleteVoucher(voucher);
            }
        }
        #endregion

        #region 3. Show all Voucher
        public void showAllVouchers(List<DTO_Voucher> vouchers)
        {
            DAO_ListVoucher dAO_listVoucher = new DAO_ListVoucher();
            foreach (DataRow row in dAO_listVoucher.showAllVouchers().Rows)
            {
                DTO_Voucher voucher = new DTO_Voucher((String)row[0], Convert.ToInt32(row[1]), (String)row[2]);
                vouchers.Add(voucher);
            }
        }
        #endregion
    }
}
