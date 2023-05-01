using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DTO
{
    public class DTO_Staff
    {
        private string idStaff;
        private string nameStaff;
        private string emailStaff;
        private string addressStaff;
        private string passwordStaff;
        private int accumulatedPointsStaff;
        private DTO_ListProduct purchaseHistoryStaff;
        private DTO_Cart cart;

        public DTO_Staff(string idStaff, string nameStaff, string passwordStaff, string emailStaff, string addressUsser, DTO_ListProduct purchaseHistoryStaff, DTO_Cart cart)
        {
            this.idStaff = idStaff;
            this.nameStaff = nameStaff;
            this.emailStaff = emailStaff;
            this.addressStaff = addressUsser;
            this.passwordStaff = passwordStaff;
            this.purchaseHistoryStaff = purchaseHistoryStaff;
            this.cart = cart;
        }

        public DTO_Staff(string idStaff, string emailStaff, string nameStaff, string passwordStaff, string addressUsser)
        {
            this.idStaff = idStaff;
            this.nameStaff = nameStaff;
            this.emailStaff = emailStaff;
            this.addressStaff = addressUsser;
            this.passwordStaff = passwordStaff;
        }

        public DTO_Staff(string id, String passwordStaff)
        {
            this.idStaff = id;
            this.passwordStaff = passwordStaff;
        }

        public string IdStaff { get {  return idStaff; } set { idStaff = value; } }

        public string NameStaff { get { return nameStaff; } set {  nameStaff = value; } }  
        public string EmailStaff { get { return emailStaff; } set { emailStaff = value; } }
        public string AddressStaff { get { return addressStaff; } set { addressStaff = value; } }
        public string PasswordStaff { get { return passwordStaff; } set {  passwordStaff = value; } }

        public int AccumulatedPointsStaff { get { return accumulatedPointsStaff; } set { accumulatedPointsStaff = value; } }

        public DTO_ListProduct PurchaseHistoryStaff { get { return purchaseHistoryStaff; } set {  purchaseHistoryStaff = value; } }    
        public DTO_Cart Cart { get {  return cart; } set { cart = value; } }
    }
}
