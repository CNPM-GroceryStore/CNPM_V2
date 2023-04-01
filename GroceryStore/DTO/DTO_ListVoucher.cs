using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ListVoucher
    {
        private List<DTO_Voucher> vouchers;

        public DTO_ListVoucher()
        {
            vouchers = new List<DTO_Voucher>();
        }

        public void Add(DTO_Voucher voucher)
        {
            vouchers.Add(voucher);
        }

        public void Remove(DTO_Voucher voucher)
        {
            vouchers.Remove(voucher);
        }

        public int Length()
        {
            return vouchers.Count;
        }

        public List<DTO_Voucher> GetAll()
        {
            return vouchers;
        }
    }
}
