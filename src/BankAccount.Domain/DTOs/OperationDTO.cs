using BankAccount.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Domain.DTOs
{
    public class OperationDTO
    {
        public float Amount { get; set; }
        public EOperationType Type { get; set; }
    }
}
