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

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        #region Crud

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Create([Required] CreateUserViewModel newUser)
        {
            try
            {
                var user = new User(newUser.Name, newUser.Email, PasswordUtil.CreateHashMD5(newUser.Password));
                var user = await _userRepository.CreateAsync(newUser);
                if (user is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Error creating record!" });

                return Created(user.Id.ToString(), new { response = new { user.Name, user.UserName, user.Email, user.CreateAt, user.FirstName } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            try
            {
                var entity = await _userRepository.GetAsync(id);
                if (entity is null) return NoContent();

                entity.SetPassword(string.Empty);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, [Required] UserViewModel updateUser)
        {
            try
            {
                if (id != updateUser.Id) return NoContent();

                var entity = await _userRepository.GetAsync(id);
                if (entity is null) return NoContent();

                entity.Update(updateUser.Name, updateUser.Email, updateUser.UserName);
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
