using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebData.Models;

namespace PetAdoptionWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_accountRepository.Accounts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_accountRepository.Accounts.FirstOrDefault(a => a.AccountId == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            _accountRepository.CreateAccount(account);
            return Ok(account);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Account account)
        {
            if (id != account.AccountId)
            {
                return BadRequest();
            }
            _accountRepository.UpdateAccount(account);
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _accountRepository.DeleteAccount(id);
            return Ok();
        }
    }
}
