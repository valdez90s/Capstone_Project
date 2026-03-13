using System;

namespace PotpotMotorShopPOS.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int ReOrderLevel { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; } = 1; // default quantity

        public decimal Total => Price * Quantity;
    }
}