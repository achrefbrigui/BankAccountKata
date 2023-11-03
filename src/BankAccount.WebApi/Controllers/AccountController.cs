using BankAccount.Application.Commands;
using BankAccount.Application.Extensions;
using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Application.Interfaces.Services;
using BankAccount.Application.Queries;
using BankAccount.Domain.DTOs;
using BankAccount.Domain.Models;
using MediatR;
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
        private readonly IAccountService _accountService;
        private IMediator _mediator;


        public AccountController(IAccountService accountService, IMediator mediator)
        {
            _accountService = accountService;
            _mediator = mediator;
        }

        /// <summary>
        /// Add an account
        /// </summary>
        /// <param name="command">Initial account balance</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Account")]
        public async Task<IActionResult> AddAccount([FromBody] AddAccountCommand command)
        {
            return Ok((await _mediator.Send(command)).Success());
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Account")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok((await _mediator.Send(new GetAllAccountsQuery())).Success());
        }

        /// <summary>
        /// Get an account by id
        /// </summary>
        /// <param name="id">Account id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Account/{id}")]
        public async Task<IActionResult> GetAccountById(string id)
        {
            return Ok((await _mediator.Send(new GetAccountByIdQuery() { Id = id })).Success());
        }

        /// <summary>
        /// Add an operation to an account
        /// </summary>
        /// <param name="id">Account id</param>
        /// <param name="command">Operation type and amount</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Account/{id}/Operations")]
        public async Task<IActionResult> AddOperation(string id, [FromBody] AddOperationCommand command)
        {
            command.Id = id;
            return Ok((await _mediator.Send(command)).Success());
        }

        /// <summary>
        /// Retrieve the operations of an account
        /// </summary>
        /// <param name="id">Account id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Account/{id}/Operations")]
        public async Task<IActionResult> GetAccountOperations(string id)
        {
            return Ok((await _mediator.Send(new GetAccountOperationsQuery() { UserId = id })).Success());
        }

        /// <summary>
        /// Retrieve the operations of an account as a paginated response
        /// </summary>
        /// <param name="id">Account id</param>
        /// <param name="pageNb">Page nb</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Account/{id}/PaginatedOperations")]
        public async Task<IActionResult> GetAccountPaginatedOperations(string id, [FromQuery] int pageNb, [FromQuery] int pageSize)
        {
            return Ok((await _mediator.Send(new GetAccountOperationsQuery() { UserId = id })).AsPagedData(pageNb, pageSize).Success());
        }
    }
}
