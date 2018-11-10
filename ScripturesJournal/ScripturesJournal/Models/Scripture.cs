using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ScripturesJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Book")]
        [Required]
        public string Book { get; set; }

        [Range(1, 200)]
        [Display(Name = "Chapter")]
        public int Chapter { get; set; }

        [Range(1, 200)]
        [Display(Name = "Verse")]
        public int Verse { get; set; }

        [StringLength(1000, MinimumLength = 3)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}
