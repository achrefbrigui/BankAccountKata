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
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountModel>
    {
        private IAccountRepo _accountRepo;

        public GetAccountByIdQueryHandler(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<AccountModel> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepo.GetByIdAsync(request.Id);
        }
    }
}
