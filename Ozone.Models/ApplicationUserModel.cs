using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string CivilId { get; set; }
        public int UnitId { get; set; }
        public Guid UnitGuId { get; set; }
        public int OrgzCategoryId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(25)]
        public string Phone { get; set; }
        public bool Active { get; set; }
        [StringLength(20)]
        public string Role { get; set; }
    }
}
