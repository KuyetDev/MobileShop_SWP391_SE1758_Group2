using Microsoft.AspNetCore.Mvc;
using MobileShop.Entity.DTOs.AccountDTO;
using MobileShop.Service;

namespace MobileShop.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("add-account")]
        public IActionResult AddAccount([FromBody] CreateAccountRequest account)
        {
            var result = _accountService.AddAccount(account);
            return Ok(result);
        }

        [HttpGet("get-account-id/{id:int}")]
        public IActionResult GetAccountById(int id)
        {
            var account = _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound("Account does not exist");
            }

            return Ok(account);
        }

        [HttpGet("get-account-mail/{mail}")]
        public IActionResult GetAccountByMail(string mail)
        {
            var account = _accountService.GetAccountByEmail(mail);
            if (account == null)
            {
                return NotFound("Account does not exist");
            }

            return Ok(account);
        }

        [HttpGet("get-account-mail-password/{mail}&{password}")]
        public IActionResult GetAccountByMailAndPassword(string mail, string password)
        {
            var account = _accountService.GetAccountByEmailAndPassword(mail, password);
            if (account == null)
            {
                return NotFound("Account does not exist");
            }

            return Ok(account);
        }


        [HttpGet("get-accounts-role/{role:int}")]
        public IActionResult GetAccountsByKeyword(int role)
        {
            var accounts = _accountService.GetAccountsByRoleId(role);
            return accounts.Count == 0 ? Ok("Don't have account") : Ok(accounts);
        }

        [HttpGet("get-accounts-keyword/{keyword}")]
        public IActionResult GetAccountsByKeyword(string keyword)
        {
            var accounts = _accountService.GetAccountsByKeyword(keyword);
            return accounts is { Count: 0 } ? Ok("Don't have account") : Ok(accounts);
        }

        [HttpGet("get-all-accounts")]
        public IActionResult GetAllAccount()
        {
            var accounts = _accountService.GetAllAccount();
            return accounts is { Count: 0 } ? Ok("Don't have account") : Ok(accounts);
        }

        [HttpPut("put-account")]
        public IActionResult UpdateAccount(UpdateAccountRequest account)
        {
            var result = _accountService.UpdateAccount(account);
            return Ok(result);
        }

        [HttpDelete("delete-account/{id:int}")]
        public IActionResult DeleteAccount(int id)
        {
            var result = _accountService.UpdateDeleteStatusAccount(id);
            if (result == false)
            {
                return StatusCode(500);
            }

            return Ok("Delete account complete");
        }
    }
}