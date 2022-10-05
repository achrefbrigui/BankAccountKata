using BankAccount.Application.Interfaces.Services;
using BankAccount.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccount.Application.Commands
{
    public class AddOperationCommandHandler : IRequestHandler<AddOperationCommand, AccountModel>
    {
        private IAccountService _accountService;

        public AddOperationCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<AccountModel> Handle(AddOperationCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.AddOperationAsync(request.Id, new Domain.Models.OperationModel { Amount = request.Amount, Type = request.Type });
        }
    }
}
