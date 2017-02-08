using System;
using System.ComponentModel.DataAnnotations;

namespace Test1.Models
{
    public class Transaction
    {
        public int ID { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public int CheckingAccountId { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}