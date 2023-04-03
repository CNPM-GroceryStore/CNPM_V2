using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_MyVoucher
    {
        public String idUser { get; set; }
        public int idVoucher { get; set; }
        public DTO_MyVoucher(string idUser, int idVoucher)
        {
            this.idUser = idUser;
            this.idVoucher = idVoucher;
        }
    }
}
