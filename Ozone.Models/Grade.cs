using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozone.Models
{
    [Table(name: "Grade", Schema = "Catalogue")]
    public class Grade
    {
        [Required]
        public int GradeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Description { get; set; }

        public ICollection<Trainee> Trainees { get; set; }
    }
}