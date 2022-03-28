using BankAccount.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankAccount.Domain.Models
{
    public class AccountModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }
        public List<OperationModel> Operations { get; set; } = new();
        public float Balance { get; set; }

        public AccountModel()
        {

        }

        public AccountModel(AccountDTO accountDTO)
        {
            this.Balance = accountDTO.Balance;
        }
    }
}
