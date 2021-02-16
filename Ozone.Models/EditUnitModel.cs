using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class EditUnitModel
    {
        public UnitModel UnitModel { get; set; }
        public IList<UnitModel> Units { get; set; }
        public IList<UnitCategoryModel> UnitCategories { get; set; }
    }
}
