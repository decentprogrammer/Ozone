using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozone.Models
{
    [Table(name: "Division", Schema = "Catalogue")]
    public class Division
    {
        [Required]
        public int DivisionId { get; set; }

        [Required]
        [StringLength(20)]
        public string Description { get; set; }
    }
}