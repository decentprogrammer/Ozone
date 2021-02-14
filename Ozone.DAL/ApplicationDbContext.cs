using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ozone.Models;

namespace Ozone.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UnitModel> UnitsTable { get; set; }
        public DbSet<UnitChecklistModel> UnitChecklistTable { get; set; }
        public DbSet<ChecklistCategoryModel> ChecklistCategoriesTable { get; set; }
        public DbSet<ChecklistElementModel> ChecklistElementsTable { get; set; }
        public DbSet<ChecklistElementDetailModel> ChecklistElementDetailsTable { get; set; }
        public DbSet<UnitCategoryModel> UnitCategoryTable { get; set; }
        public DbSet<ApplicationUserModel> ApplicationUsersTable { get; set; }
        public DbSet<VendorDictionaryModel> VendorsDictionaryTable { get; set; }
    }
}
