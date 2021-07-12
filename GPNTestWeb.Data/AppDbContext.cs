using GPNTestWeb.Model.Entity;
using GPNTestWeb.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace GPNTestWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SaleItem> SaleItems { get; set; }
    }
}
