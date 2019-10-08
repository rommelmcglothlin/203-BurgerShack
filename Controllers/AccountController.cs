using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
    private readonly AccountService _accountService;

    [HttpPost("register")]
        public ActionResult<User> Register([FromBody] UserRegistration creds)
        {
            try
            {
                User u = _accountService.Register(creds);
                return Ok(u);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult<User> SignIn([FromBody] UserSignIn creds)
        {
            try
            {
                User u = _accountService.SignIn(creds);
                return Ok(u);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

    }
}