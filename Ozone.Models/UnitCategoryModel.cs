using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class UnitCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150),Required]
        public string CategoryName { get; set; }
        [StringLength(15), Required]
        public string CategoryNameExpr { get; set; }

    }
}
