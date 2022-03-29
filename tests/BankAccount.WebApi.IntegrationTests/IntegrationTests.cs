using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Application.Interfaces.Services;
using BankAccount.Application.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankAccount.WebApi.IntegrationTests
{
    public partial class IntegrationTests : IClassFixture<WebAppFactoryTest>
    {
        private readonly HttpClient _client;
        private readonly AccountService _accountService;
        private readonly Mock<IAccountService> _accountServiceMock = new Mock<IAccountService>();
        private readonly Mock<IAccountRepo> _accountRepoMock = new Mock<IAccountRepo>();

        public IntegrationTests(WebAppFactoryTest factory)
        {
            _client = factory.CreateClient();
            _accountService = new AccountService(_accountRepoMock.Object);
        }
    }
}
