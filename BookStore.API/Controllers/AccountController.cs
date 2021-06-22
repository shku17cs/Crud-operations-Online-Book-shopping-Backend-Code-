using BookStore.API.Models;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        

        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController>logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;

        }
        /*public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }*/
        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            _logger.LogInformation("reach signup page");
            try
            {
                throw new Exception();
            }
            catch(Exception ex )
            {
                _logger.LogError(ex,"this exception from signup page");
            }
            var result = await _accountRepository.SignUpAsync(signUpModel);
            
            if(result.Succeeded)
            {
                return Ok(true);
            }
            return Unauthorized();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            _logger.LogInformation("reach signup page");
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "this exception from signup page");
            }
            var result = await _accountRepository.LoginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
