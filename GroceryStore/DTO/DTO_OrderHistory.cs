using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_OrderHistory
    {
        public string id;
        public int price;
        public int amount;
        public string paymethod;
        public string status;
        public string paydate;

        public DTO_OrderHistory(string id, int price, int amount, string paymethod, string status, string paydate)
        {
            this.id = id;
            this.price = price;
            this.amount = amount;
            this.paymethod = paymethod;
            this.status = status;
            this.paydate = paydate;
        }

        public DTO_OrderHistory(int price, int amount, string paymethod, string status, string paydate)
        {
            this.price = price;
            this.amount = amount;
            this.paymethod = paymethod;
            this.status = status;
            this.paydate = paydate;
        }

        public string Id { get { return id; } set { id = value; } }
        public int Price { get { return price; } set { price = value; } }
        public int Amount { get { return amount; } set { amount = value; } }
        public string Paymethod { get {  return paymethod; } set {  paymethod = value; } }
        public string Status { get { return status; }
            set
            {
                status = value;
            } }
        public string Paydate { get {  return paydate; } set { paydate = value; } }


    }
}
