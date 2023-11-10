using Jcf.Challenge.Server.Extensions.Utils;
using Jcf.Challenge.Server.Models.ViewModels;
using Jcf.Challenge.Server.Repositories;
using Jcf.Challenge.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Challenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : MyController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AccountController(ILogger<AccountController> logger, IUserRepository userRepository, ITokenService tokenService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        #region Authenticate

        [HttpPost, AllowAnonymous]      
        public async Task<IActionResult> Login([FromBody] LoginViewModel viewModel)
        {
            try
            {
                var user = await _userRepository.AuthenticateAsync(viewModel.Email, PasswordUtil.CreateHashMD5(viewModel.Password));
                if (user == null) return BadRequest(new { error = true, message = "Usuário ou Senha Inválida!" });

                return Ok(new
                {
                    auth = true,
                    user = new
                    {
                        user.Id,
                        user.Email,
                        user.Name,
                        user.FirstName
                    },
                    token = _tokenService.NewToken(user),
                    message = "Usuário Autenticado"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        #endregion
    }
}
