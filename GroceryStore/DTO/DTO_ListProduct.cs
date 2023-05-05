using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ListProduct
    {
        private List<DTO_Product> products;

        public DTO_ListProduct()
        {
            products = new List<DTO_Product>();
        }
    }
}
