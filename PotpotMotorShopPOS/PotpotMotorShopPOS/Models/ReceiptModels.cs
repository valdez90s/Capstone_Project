using System;
using System.Collections.Generic;

namespace PotpotMotorShopPOS.Models
{
    /// <summary>
    /// Receipt header information
    /// </summary>
    public class ReceiptHeader
    {
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }
        public string Cashier { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VATRate { get; set; }
        public decimal VATAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyTIN { get; set; }
        public long TransactionID { get; set; }
        public string ReferenceNo { get; set; }
    }

    /// <summary>
    /// Receipt line item
    /// </summary>
    public class ReceiptItem
    {
        public string InvoiceNo { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

    /// <summary>
    /// Complete receipt data for printing
    /// </summary>
    public class ReceiptData
    {
        public ReceiptHeader Header { get; set; }
        public List<ReceiptItem> Items { get; set; }

        public ReceiptData()
        {
            Items = new List<ReceiptItem>();
        }
    }
}