using BankAccount.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<AccountModel> Account { get; set; }
        public virtual DbSet<OperationModel> Operations { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
