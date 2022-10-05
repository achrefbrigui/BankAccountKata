using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Application.Interfaces.Services
{
    public interface IAccountService : IAccountRepo
    {
        Task<AccountModel> AddOperationAsync(string accountId, OperationModel operation);
    }
}
