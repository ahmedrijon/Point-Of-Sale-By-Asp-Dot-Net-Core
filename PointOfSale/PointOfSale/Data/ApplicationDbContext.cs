using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PointOfSale.Models;

namespace PointOfSale.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PointOfSale.Models.Salesman> Salesman { get; set; }
        public DbSet<PointOfSale.Models.Supplier> Supplier { get; set; }
    }
}
