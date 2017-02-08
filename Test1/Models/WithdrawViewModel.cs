using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class WithdrawViewModel
    {
        [Required]
        [RegularExpression(@"\d{6,16}", ErrorMessage = "Account number must be between 6 and 16")]
        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }

        public IEnumerable<string> AccountNumbers { get; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public WithdrawViewModel()
        {
            var db = ApplicationDbContext.Create();
            AccountNumbers = db.CheckingAccounts.Select(ac => ac.AccountNumber);
        }
    }
}
