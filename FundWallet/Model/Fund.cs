using System;
namespace FundWallet.Model
{
    public class Fund
    {

        private string Name { get; set; }
        private string Quantity { get; set; }
        private string UnitPrice { get; set; }
        private DateTime PurchaseDate { get; set; }

        public Fund(string name, string quantity, string price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.UnitPrice = price;
            this.PurchaseDate = new DateTime();
        }
    }
}
