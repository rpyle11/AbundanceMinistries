using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbLedger.Entities
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Account { get; set; }

        [Required]
        public bool? Active { get; set; }

        public List<Transactions> Transactions { get; set; }
    }
}
