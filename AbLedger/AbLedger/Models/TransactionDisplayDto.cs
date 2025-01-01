using System;

namespace AbLedger.Models
{
    public class TransactionDisplayDto
    {
        public int Id { get; set; }
        public DateTime TransDate { get; set; }

        public string CheckNum { get; set; }

        public string Payee { get; set; }
        public string Account { get;set; }
        public string Memo { get; set; }

        public decimal? Payment { get; set; }
        public decimal? Deposit { get; set; }

        public decimal? EndingBalance { get; set; }
        public decimal? BeginningBalance { get; set; }
    }
}
