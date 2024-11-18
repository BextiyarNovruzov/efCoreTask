using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Identity.Client;

namespace EFCore.Context
{
    public class AppDbContext : DbContext
    {
        //Users, Basket və Products deyə cədvəllərimiz var.
        public DbSet<users> Users { set; get; }
        public DbSet<products> Products { set; get; }
        public DbSet<baskets> Baskets { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS; Database = efcore; Trusted_Connection = True;TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
