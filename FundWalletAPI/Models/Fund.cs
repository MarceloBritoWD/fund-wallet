using System;
using System.ComponentModel.DataAnnotations;

namespace FundWalletAPI.Models
{
    public class Fund
    {
        [Key] public int FundId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public double UnitPrice { get; set; }
        [Required] private DateTime PurchaseDate { get; set; }
    }
}
