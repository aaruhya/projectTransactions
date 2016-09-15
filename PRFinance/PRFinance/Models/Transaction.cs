using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PRFinance.Models
{
    public enum CategoryEnum
    {
        Food = 0,
        Gas = 1,
        Clothing = 2,
        Rent = 3,
        Classes = 4,
        Restraunt = 5,
        Grocery = 6,
        Entertainment = 7,
        Misc = 8,
        OneTime = 9,
        Bills = 10,
        All = 50
    }

    public class Transaction
    {
        public string ID { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        public CategoryEnum Category { get; set; }

        [Range(-10000000, 10000000)]
        [DataType(DataType.Currency)]
        public double Expense { get; set; }

        //[StringLength(100)]
        public string Comment { get; set; }
    }

    public class TransactionDBContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
    }

}