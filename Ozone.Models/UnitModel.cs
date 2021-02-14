using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class UnitModel
    {
        [Key]
        public int Id { get; set; }

        public Guid UnitGuId { get; set; }
        [Required]
        [StringLength(300)]
        public string EnglishName { get; set; }
        [Required]
        [StringLength(300)]
        public string ArabicName { get; set; }
        [StringLength(10)]
        public string NameAbbreviation { get; set; }
        [Required]
        [StringLength(300)]
        public string Location { get; set; }
        [Required]
        [StringLength(300)]
        public string ResponsibleName { get; set; }
        [Required]
        public string Description { get; set; }
        [StringLength(300)]
        public string Email { get; set; }
        [StringLength(15)]
        public string Telephone { get; set; }
        [StringLength(8)]
        public string InternalTel_1 { get; set; }
        [StringLength(8)]
        public string InternalTel_2 { get; set; }
        [StringLength(15)]
        public string Mobile { get; set; }
        [StringLength(15)]
        public string Fax { get; set; }
        [StringLength(100)]
        public string PersonToCantact { get; set; }
        public int ParentId { get; set; }
        [StringLength(300)]
        public string ParentName { get; set; }
        [StringLength(150)]
        public string Category { get; set; }

        public IList<UnitCategoryModel> UnitCategories { get; set; }



    }
}
