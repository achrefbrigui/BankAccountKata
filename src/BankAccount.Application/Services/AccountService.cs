using BankAccount.Application.Exceptions;
using BankAccount.Application.Extensions;
using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Application.Interfaces.Services;
using BankAccount.Application.Wrappers;
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

        public async Task<AccountModel> AddAsync(AccountModel entity)
        {
            return await _accountRepo.AddAsync(entity);
        }

        public async Task<AccountModel> AddOperationAsync(string accountId, OperationModel operation)
        {
            var acc = await _accountRepo.GetByIdAsync(accountId);
            if (acc is null) throw new NotFoundException(nameof(AccountModel));
            if (operation.Amount < 0) throw new BadRequestException("The operation amount should be positive");
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

        public async Task DeleteAsync(AccountModel entity)
        {
            await _accountRepo.DeleteAsync(entity);
        }

        public async Task<List<AccountModel>> GetAllAsync()
        {
            return await _accountRepo.GetAllAsync();
        }

        public async Task<AccountModel> GetByIdAsync(string id)
        {
            return await _accountRepo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AccountModel entity)
        {
            await _accountRepo.UpdateAsync(entity);
        }
    }
}
