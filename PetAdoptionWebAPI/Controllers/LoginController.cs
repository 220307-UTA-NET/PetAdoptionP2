using Microsoft.AspNetCore.Mvc;
using WebData.Models;

namespace PetAdoptionWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public LoginController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            var result = _accountRepository.Accounts.FirstOrDefault(a => a.UserName == account.UserName && a.Password == account.Password);
            if (result == null)
            {
                return NotFound();
            } else
            {
                return Ok(result);
            }   
        }
    }
}