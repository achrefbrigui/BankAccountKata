using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity) : base($"Entity {entity} was not found")
        {

        }
    }
}
