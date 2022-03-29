using BankAccount.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Application.Interfaces.Repositories
{
    public interface IOperationRepo : IGenericRepo<OperationModel>
    {
    }
}
