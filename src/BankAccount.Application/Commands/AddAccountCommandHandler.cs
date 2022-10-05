using BankAccount.Application.Interfaces.Services;
using BankAccount.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccount.Application.Commands
{
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, AccountModel>
    {
        private IAccountService _accountService;

        public AddAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<AccountModel> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.AddAsync(new AccountModel() { Balance = request.Balance });
        }
    }
}
