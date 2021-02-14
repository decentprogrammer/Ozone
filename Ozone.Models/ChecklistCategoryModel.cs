using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class ChecklistCategoryModel
    {
        [Key]
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public Guid HelpId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Public Visible")]
        public bool PublicVisible { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Status { get; set; }

        public List<ChecklistElementModel> ChecklistElementsModel { get; set; }

        public int UnitChecklistId { get; set; }
        public UnitChecklistModel UnitChecklistModel { get; set; }
    }
}
