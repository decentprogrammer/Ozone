using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class UnitChecklistModel
    {
        [Key]
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        [Required]
        public bool PublicVisible { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required]
        [StringLength(20)]
        public string GeneralStatus { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string Description { get; set; }
        public List<ChecklistCategoryModel> ChecklistCategoriesModel { get; set; }
        public int UnitID { get; set; }
        public UnitModel UnitModel { get; set; }
    }
}
