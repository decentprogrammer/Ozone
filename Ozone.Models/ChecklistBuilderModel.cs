using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class ChecklistBuilderModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public IList<ChecklistElementModel> checklistElementsList { get; set; }

    }
}
