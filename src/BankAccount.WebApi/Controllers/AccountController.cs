using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Application.Interfaces.Services;
using BankAccount.Domain.DTOs;
using BankAccount.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.WebApi.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IAccountService _accountService;
        private readonly IGenericRepo<OperationModel> _operationRepo;

        public AccountController(IAccountRepo accountRepo, IAccountService accountService, IGenericRepo<OperationModel> operationRepo)
        {
            _accountRepo = accountRepo;
            _accountService = accountService;
            _operationRepo = operationRepo;
        }

        [HttpPost]
        [Route("Account")]
        public async Task<IActionResult> AddAccount([FromBody] AccountDTO account)
        {
            return Ok(await _accountRepo.AddAsync(new AccountModel(account)));
        }

        [HttpGet]
        [Route("Account")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(await _accountRepo.GetAllAsync());
        }

        [HttpGet]
        [Route("Account/{id}")]
        public async Task<IActionResult> GetAccountById(string id )
        {
            return Ok(await _accountRepo.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("Account/{id}/Operations")]
        public async Task<IActionResult> AddOperation(string id, [FromBody] OperationDTO operation)
        {
            return Ok(await _accountService.AddOperationAsync(id, new OperationModel(operation)));
        }

        [HttpGet]
        [Route("Account/{id}/Operations")]
        public async Task<IActionResult> GetAccountOperations(string id)
        {
            return Ok((await _accountRepo.GetByIdAsync(id)).Operations);
        }
    }
}
