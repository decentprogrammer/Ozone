using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ozone.Models
{
    [Table(name: "Gender", Schema = "Catalogue")]
    public class Gender
    {
        [Required]
        public int GenderId { get; set; }

        [Required]
        [StringLength(10)]
        public string Description { get; set; }

        public ICollection<Trainee> Trainees { get; set; }
    }
}
