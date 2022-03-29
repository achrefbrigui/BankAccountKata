using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Infrastructure.Persistence.Repositories
{
    public class AccountRepo : GenericRepo<AccountModel>, IAccountRepo
    {
        private readonly AppDbContext _context;
        public AccountRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public new async Task<AccountModel> GetByIdAsync(string id)
        {
            return await _context.Account.Include(a=>a.Operations).FirstOrDefaultAsync(a=>a.Id==id);
        }
    }
}
