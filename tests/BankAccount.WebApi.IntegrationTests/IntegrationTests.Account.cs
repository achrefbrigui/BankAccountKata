using BankAccount.Application.Wrappers;
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
        public async Task Post_DepositOperation_ShouldSuccess(
            float amount1,float amount2, float expectedBalance)
        {
            var accs = await AddAccountAsync();

            await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount1, Type = Domain.Enums.EOperationType.Deposit });
            using var opsReq = await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount2, Type = Domain.Enums.EOperationType.Deposit });
            var res = JsonConvert.DeserializeObject<Response<AccountModel>>(await opsReq.Content.ReadAsStringAsync());

            Assert.Equal(res.Data.Balance, expectedBalance);
            Assert.True(res.Succeeded);
        }

        [Theory]
        [InlineData(300, 500, 200)]
        [InlineData(100, 50, -50)]
        public async Task Post_WithdrawOperation_ShouldSuccess(
            float amount, float initialBalance, float expectedBalance)
        {
            var accs = await AddAccountAsync();

            await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = initialBalance, Type = Domain.Enums.EOperationType.Deposit });

            using var opsReq = await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount, Type = Domain.Enums.EOperationType.Withdrawal });
            var res = JsonConvert.DeserializeObject<Response<AccountModel>>(await opsReq.Content.ReadAsStringAsync());

            Assert.Equal(res.Data.Balance, expectedBalance);
            Assert.True(res.Succeeded);
        }

        [Theory]
        [InlineData(-300)]
        [InlineData(-100)]
        public async Task Post_WithdrawOperation_ShouldReturnBadRequest_WithNegativeAmount(
            float amount)
        {
            var accs = await AddAccountAsync();

            await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount, Type = Domain.Enums.EOperationType.Deposit });

            using var opsReq = await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount, Type = Domain.Enums.EOperationType.Withdrawal });
            var res = JsonConvert.DeserializeObject<Response<AccountModel>>(await opsReq.Content.ReadAsStringAsync());

            Assert.False(res.Succeeded);
        }

        [Theory]
        [InlineData(-300)]
        [InlineData(-100)]
        public async Task Post_DepositOperation_ShouldReturnBadRequest_WithNegativeAmount(
           float amount)
        {
            var accs = await AddAccountAsync();

            var opsReq = await _client.PostAsJsonAsync($"Account/{accs.Id}/Operations", new OperationDTO() { Amount = amount, Type = Domain.Enums.EOperationType.Deposit });
            var res = JsonConvert.DeserializeObject<Response>(await opsReq.Content.ReadAsStringAsync());

            Assert.True(opsReq.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.False(res.Succeeded);
        }

        [Theory]
        [InlineData(-300)]
        [InlineData(-100)]
        public async Task Post_DepositOperation_ShouldReturnNotFound_WithInvalidAccountId(
           float amount)
        {
            var opsReq = await _client.PostAsJsonAsync($"Account/{new Guid().ToString()}/Operations", new OperationDTO() { Amount = amount, Type = Domain.Enums.EOperationType.Deposit });
            var res = JsonConvert.DeserializeObject<Response>(await opsReq.Content.ReadAsStringAsync());

            Assert.False(res.Succeeded);
            Assert.True(opsReq.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_Account_ShouldRetrieveById()
        {
            var accs = await AddAccountAsync();

            using var opsReq = await _client.GetAsync($"Account/{accs.Id}");
            var res = JsonConvert.DeserializeObject<Response<AccountModel>>(await opsReq.Content.ReadAsStringAsync());

            Assert.True(res.Succeeded);
            Assert.True(opsReq.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal(accs.Id, res.Data.Id);
        }
    }
}
