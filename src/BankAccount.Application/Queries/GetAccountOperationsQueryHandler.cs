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
    public class GetAccountOperationsQueryHandler : IRequestHandler<GetAccountOperationsQuery, List<OperationModel>>
    {
        private IAccountRepo _accountRepo;

        public GetAccountOperationsQueryHandler(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<List<OperationModel>> Handle(GetAccountOperationsQuery request, CancellationToken cancellationToken)
        {
            return (await _accountRepo.GetByIdAsync(request.UserId)).Operations;
        }
    }
}
