using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }
        public int Amount { get; set; }
        public string ImageProduct { get; set; }
        public string TypeProduct { get; set; }

        public string Shipment { get; set; }
        public string Shelflife { get; set; }

        public DTO_Product(int idProduct, string nameProduct, int amount, int priceProduct, string imageProduct, string typeProduct, string shipment, string shelflife)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            Amount = amount;
            PriceProduct = priceProduct;
            ImageProduct = imageProduct;
            TypeProduct = typeProduct;
            Shipment = shipment;
            Shelflife = shelflife;
        }
        public DTO_Product(string nameProduct, int priceProduct, string imageProduct, string typeProduct)
        {
            NameProduct = nameProduct;
            PriceProduct = priceProduct;
            ImageProduct = imageProduct;
            TypeProduct = typeProduct;
        }
        public DTO_Product(string nameProduct, int priceProduct, string imageProduct)
        {
            NameProduct = nameProduct;
            PriceProduct = priceProduct;
            ImageProduct = imageProduct;
        }

        public DTO_Product(int idProduct)
        {
            this.IdProduct = idProduct;
        }

        public DTO_Product(string nameProduct, int amount, int priceProduct, string imageProduct, string typeProduct, string shipment, string shelflife)
        {
            NameProduct = nameProduct;
            Amount = amount;
            PriceProduct = priceProduct;
            ImageProduct = imageProduct;
            TypeProduct = typeProduct;
            Shipment = shipment;
            Shelflife = shelflife;
        }
    }
}
