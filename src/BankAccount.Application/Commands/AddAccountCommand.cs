using BankAccount.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Application.Commands
{
    public class AddAccountCommand : IRequest<AccountModel>
    {
        public float Balance { get; set; }
    }
}
