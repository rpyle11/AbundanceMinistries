using System;
using System.ComponentModel.DataAnnotations;

namespace AbLedger.Entities
{
    public class AppErrors
    {
        [Key]
        public int Id { get;set; }

        [Required]
        [MaxLength(1500)]
        public string ErrorMsg { get; set; }

        [Required]
        [MaxLength(50)]
        public string AppMethod { get; set; }

        [Required]
        public DateTime? ErrorDate { get; set; }
    }
}
