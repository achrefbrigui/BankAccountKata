using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccount.Application.Queries
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, List<AccountModel>>
    {
        private IAccountRepo _accountRepo;

        public GetAllAccountsQueryHandler(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<List<AccountModel>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepo.GetAllAsync();
        }
    }
}
