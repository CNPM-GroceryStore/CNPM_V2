using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DTO
{
    public class DTO_Cart
    {
        private string idCart;
        private DTO_ListProduct products;

        public DTO_Cart(DTO_ListProduct products) 
        {
            this.products = products;
        }

        public string IdCart { get {  return idCart; } set { idCart = value; } }

        public DTO_ListProduct Products { get {  return products; } set { products = value; } }

    }
}
