using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataImport.Entities
{
    public class Payees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayeeName { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [Required]
        public bool? Active { get; set; }

        public List<Transactions> Transactions { get; set; }
    }
    
}
