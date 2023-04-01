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

        public void Add(DTO_Product product)
        {
            products.Add(product);
        }

        public void Remove(DTO_Product product)
        {
            products.Remove(product);
        }

        public int Length()
        {
            return products.Count;
        }

        public List<DTO_Product> GetAll()
        {
            return products;
        }
    }
}
