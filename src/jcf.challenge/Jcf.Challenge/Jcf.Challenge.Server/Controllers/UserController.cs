using Jcf.Challenge.Server.Extensions.Utils;
using Jcf.Challenge.Server.Models;
using Jcf.Challenge.Server.Models.ViewModels;
using Jcf.Challenge.Server.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Jcf.Challenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : MyController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        #region Crud

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([Required] CreateUserViewModel newUser)
        {
            try
            {
                if (await _userRepository.UserNameInUseAsync(newUser.Email))
                    return Conflict(new { StatusCode = HttpStatusCode.Conflict, error = true, message = "Email já cadastrado!", newUser.Email });

                var user = new User(newUser.Name, newUser.Email, newUser.Email, PasswordUtil.CreateHashMD5(newUser.Password));
                user = await _userRepository.CreateAsync(user);
                if (user is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Erro ao criar usuário!" });

                return Created(user.Id.ToString(), new { response = new { StatusCode = HttpStatusCode.Created, message = "Cadastrado!", user.Id, user.Name, user.FirstName, user.UserName, user.Email, user.CreatedAt } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, error = true, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            try
            {
                var entity = await _userRepository.GetByIdAsync(id);
                if (entity is null) return NoContent();

                entity.ClearPassword();
                return Ok(entity);
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
