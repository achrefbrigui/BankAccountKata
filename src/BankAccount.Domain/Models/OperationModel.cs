using BankAccount.Domain.DTOs;
using BankAccount.Domain.Enums;
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
    public class OperationModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        [JsonIgnore]
        public AccountModel Account { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public EOperationType Type { get; set; }

        public OperationModel()
        {

        }

        public OperationModel(OperationDTO operationDTO)
        {
            this.Amount = operationDTO.Amount;
            this.Type = operationDTO.Type;
        }
    }
}
