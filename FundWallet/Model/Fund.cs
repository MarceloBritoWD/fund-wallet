using System;
namespace FundWallet.Model
{
    public class Fund
    {

        public int fundId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
