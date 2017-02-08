using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class CheckingAccount
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"\d{6,16}", ErrorMessage = "Account number must be between 6 and 16")]
        [StringLength(16)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string LastName { get; set; }

        public string Name { get { return FirstName + " " + LastName; } }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}