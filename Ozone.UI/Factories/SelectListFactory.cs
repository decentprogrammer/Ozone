using Microsoft.AspNetCore.Mvc.Rendering;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.UI.Factories
{
    public class SelectListFactory
    {
        public SelectListFactory()
        {

        }

        public static SelectListItem Create(Gender entity)
        {
            return new SelectListItem()
            {
                Value = entity.GenderId.ToString(),
                Text = entity.Description
            };
        }
    }
}
