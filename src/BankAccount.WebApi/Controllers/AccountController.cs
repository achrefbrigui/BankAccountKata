using BankAccount.Application.Extensions;
using BankAccount.Application.Interfaces.Services;
using BankAccount.Domain.DTOs;
using BankAccount.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankAccount.WebApi.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("Account")]
        public async Task<IActionResult> AddAccount([FromBody] AccountDTO account)
        {
            return Ok((await _accountService.AddAsync(new AccountModel(account))).Success());
        }

        [HttpGet]
        [Route("Account")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok((await _accountService.GetAllAsync()).Success());
        }

        [HttpGet]
        [Route("Account/{id}")]
        public async Task<IActionResult> GetAccountById(string id)
        {
            return Ok((await _accountService.GetByIdAsync(id)).Success());
        }

        [HttpPost]
        [Route("Account/{id}/Operations")]
        public async Task<IActionResult> AddOperation(string id, [FromBody] OperationDTO operation)
        {
            return Ok((await _accountService.AddOperationAsync(id, new OperationModel(operation))).Success());
        }

        [HttpGet]
        [Route("Account/{id}/Operations")]
        public async Task<IActionResult> GetAccountOperations(string id)
        {
            return Ok((await _accountService.GetByIdAsync(id)).Operations.Success());
        }

        [HttpGet]
        [Route("Account/{id}/PaginatedOperations")]
        public async Task<IActionResult> GetAccountPaginatedOperations(string id, [FromQuery] int pageNb, [FromQuery] int pageSize )
        {
            return Ok((await _accountService.GetByIdAsync(id)).Operations.AsPagedData(pageNb,pageSize).Success());
        }
    }
}
