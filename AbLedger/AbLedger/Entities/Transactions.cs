using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbLedger.Entities
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime? TransDate { get; set; }
        [MaxLength(50)]
        public string CheckNum { get; set; }

        [MaxLength(1000)]
        public string Memo { get; set; }

        public bool Payment { get; set; }
        public bool Deposit { get; set; }

        public decimal? TransAmount { get; set; }

        public decimal? EndBalance { get; set; }
        public decimal? BeginBalance { get; set; }

        public int PayeeId { get; set; }
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Accounts Account { get; set; }

        [ForeignKey("PayeeId")]
        public virtual Payees Payees { get; set; }
    }
}
