using BankAccount.Domain.DTOs;
using BankAccount.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankAccount.WebApi.IntegrationTests
{
    public partial class IntegrationTests
    {
        [Theory]
        [InlineData(300,400,700)]
        [InlineData(200,120,320)]
        public async Task Post_DepositOperation(
            float amount1,float amount2, float expectedBalance)
        {
            var accs = await AddAccountAsync();

            await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount1, Type = Domain.Enums.EOperationType.Deposit });
            using var opsReq = await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount2, Type = Domain.Enums.EOperationType.Deposit });
            var acc = JsonConvert.DeserializeObject<AccountModel>(await opsReq.Content.ReadAsStringAsync());

            Assert.Equal(acc.Balance, expectedBalance);
        }

        [Theory]
        [InlineData(300, 500, 200)]
        [InlineData(100, 50, -50)]
        public async Task Post_WithdrawOperation(
            float amount, float initialBalance, float expectedBalance)
        {
            var accs = await AddAccountAsync();

            await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = initialBalance, Type = Domain.Enums.EOperationType.Deposit });

            using var opsReq = await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount, Type = Domain.Enums.EOperationType.Withdrawal });
            var acc = JsonConvert.DeserializeObject<AccountModel>(await opsReq.Content.ReadAsStringAsync());

            Assert.Equal(acc.Balance, expectedBalance);
        }
    }
}
