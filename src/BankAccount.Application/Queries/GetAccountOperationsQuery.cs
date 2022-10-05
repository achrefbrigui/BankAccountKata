using BankAccount.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Application.Queries
{
    public class GetAccountOperationsQuery : IRequest<List<OperationModel>>
    {
        public string UserId { get; set; }
    }
}
