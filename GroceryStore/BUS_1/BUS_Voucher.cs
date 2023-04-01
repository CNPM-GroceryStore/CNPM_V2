using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.BUS
{
    public class BUS_Voucher
    {
        #region 1. Insert Voucher
        public bool insertVoucher(DTO_Voucher voucher)
        {
            DAO_Voucher dAO_Voucher = new DAO_Voucher();
            if (!dAO_Voucher.checkExistsVoucher(voucher))
            {
                dAO_Voucher.insertVoucher(voucher);
                return true;
            }
            return false;
        }
        #endregion

        #region 2. Delete Voucher
        public DAO_Voucher deleteVoucher(DTO_Voucher voucher)
        {
            DAO_Voucher dAO_voucher = new DAO_Voucher();
            dAO_voucher.deleteVoucher(voucher);
            return dAO_voucher;
        }
        #endregion

        #region 3. Update Voucher
        public DTO_Voucher updateVoucher(DTO_Voucher voucher)
        {
            DAO_Voucher dAO_Voucher = new DAO_Voucher();
            dAO_Voucher.updateVoucher(voucher);
            return voucher;
        }
        #endregion
    }
}
