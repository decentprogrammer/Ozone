using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class ChecklistElementModel
    {
        [Key]
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public Guid HelpId { get; set; }
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        [Required]
        [StringLength(300)]
        public string Location { get; set; }
        [Required]
        [DisplayName("Room Number")]
        [StringLength(100)]
        public string RoomNumber { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Brand Name")]
        [StringLength(300)]
        public string BrandName { get; set; }

        [Required]
        [DisplayName("Vendor Name")]
        [StringLength(300)]
        public string VendorName { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        [StringLength(20)]
        public string ProcessStatus { get; set; }
        [Required]
        [DisplayName("Public Visible")]
        public bool PublicVisible { get; set; }
        [Required]
        [DisplayName("Element Rank")]
        [StringLength(20)]
        public string ElementRank { get; set; }
        [Required]
        [DisplayName("Install Date")]
        public DateTime Installed { get; set; }
        [Required]
        [DisplayName("Replace Date")]
        public DateTime Replace { get; set; }
        public int VendorId { get; set; }

        public List<ChecklistElementDetailModel> ChecklistElementDetailsModel { get; set; }


        public int CartegoryId { get; set; }
        public ChecklistCategoryModel ChecklistCategoryModel { get; set; }
    }
}
