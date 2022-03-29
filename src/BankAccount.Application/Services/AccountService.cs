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
            var acc = await _accountRepo.GetByIdAsync(accountId);
            switch (operation.Type)
            {
                case Domain.Enums.EOperationType.Deposit:
                    acc.Balance += operation.Amount;
                    break;
                case Domain.Enums.EOperationType.Withdrawal:
                    acc.Balance -= operation.Amount;
                    break;
                default:
                    break;
            }
            acc.Operations.Add(operation);
            await _accountRepo.UpdateAsync(acc);

            return acc;
        }
    }
}
