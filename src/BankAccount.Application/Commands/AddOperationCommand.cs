using System;
using BankAccount.Domain.Enums;
using BankAccount.Domain.Models;
using MediatR;

namespace BankAccount.Application.Commands
{
    public class AddOperationCommand : IRequest<AccountModel>
    {
        public string Id { get; set; }
        public float Amount { get; set; }
        public EOperationType Type { get; set; }
    }
}
