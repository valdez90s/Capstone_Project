using System;

namespace PotpotMotorShopPOS.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string PlateNo { get; set; }
        public string MotorType { get; set; }
        public string MotorModel { get; set; }

        // Convenience property para sa display
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}