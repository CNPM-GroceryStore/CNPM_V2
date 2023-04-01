using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DTO
{
    public class DTO_User
    {
        private string idUser;
        private string nameUser;
        private string emailUser;
        private string addressUser;
        private string passwordUser;
        private DTO_ListProduct purchaseHistoryUser;
        private DTO_Cart cart;

        public DTO_User(string idUser, string nameUser, string passwordUser, string emailUser, string addressUsser, DTO_ListProduct purchaseHistoryUser, DTO_Cart cart)
        {
            this.idUser = idUser;
            this.nameUser = nameUser;
            this.emailUser = emailUser;
            this.addressUser = addressUsser;
            this.passwordUser = passwordUser;
            this.purchaseHistoryUser = purchaseHistoryUser;
            this.cart = cart;
        }

        public DTO_User(string idUser, string nameUser, string passwordUser, string emailUser, string addressUsser)
        {
            this.idUser = idUser;
            this.nameUser = nameUser;
            this.emailUser = emailUser;
            this.addressUser = addressUsser;
            this.passwordUser = passwordUser;
        }

        public DTO_User(string id, String passwordUser)
        {
            this.idUser = id;
            this.passwordUser = passwordUser;
        }

        public string IdUser { get {  return idUser; } set { idUser = value; } }

        public string NameUser { get { return nameUser; } set {  nameUser = value; } }  
        public string EmailUser { get { return emailUser; } set { emailUser = value; } }
        public string AddressUser { get { return addressUser; } set { addressUser = value; } }
        public string PasswordUser { get { return passwordUser; } set {  passwordUser = value; } }  
        public DTO_ListProduct PurchaseHistoryUser { get { return purchaseHistoryUser; } set {  purchaseHistoryUser = value; } }    
        public DTO_Cart Cart { get {  return cart; } set { cart = value; } }
    }
}
