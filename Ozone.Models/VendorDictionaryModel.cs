using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class VendorDictionaryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string VendorName { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductAndService { get; set; }
        [StringLength(300)]
        public string Email { get; set; }
        [StringLength(25)]
        public string Tel { get; set; }
        [StringLength(25)]
        public string Mobile { get; set; }
        [StringLength(25)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

    }
}
