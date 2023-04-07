using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ProductCart
    {
        private String id;
        private String name;
        private int price;
        private int quantity;

        public DTO_ProductCart(String id, String name, int price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public String ID { get { return id; } set { id = value; } }
        public String Name { get { return name; } set { name = value; } }
        public int Price { get { return price; } set { price = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
    }
}
