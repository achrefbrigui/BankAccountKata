using BankAccount.Application.Commands;
using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Application.Interfaces.Services;
using BankAccount.Application.Services;
using BankAccount.Application.Wrappers;
using BankAccount.Domain.Models;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankAccount.WebApi.IntegrationTests
{
    public partial class IntegrationTests : IClassFixture<WebAppFactoryTest>
    {
        private readonly HttpClient _client;

        public IntegrationTests(WebAppFactoryTest factory)
        {
            _client = factory.CreateClient();
        }

        public async Task<AccountModel> AddAccountAsync()
        {
            using var accReq = await _client.PostAsJsonAsync("Account", new AddAccountCommand());
            var res = JsonConvert.DeserializeObject<Response<AccountModel>>(await accReq.Content.ReadAsStringAsync());
            return res.Data;
        }
    }
}
