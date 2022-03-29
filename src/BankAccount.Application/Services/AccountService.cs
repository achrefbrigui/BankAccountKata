using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Application.Interfaces.Services;
using BankAccount.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;

        public AccountService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<AccountModel> AddOperationAsync(string accountId, OperationModel operation)
        {
            throw new NotImplementedException();
        }
    }
}
