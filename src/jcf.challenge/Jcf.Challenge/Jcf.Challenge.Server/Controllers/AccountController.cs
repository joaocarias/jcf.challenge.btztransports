using Microsoft.AspNetCore.Mvc;

namespace Jcf.Challenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : MyController
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        #region Crud

        #endregion

        #region Authenticate



        #endregion
    }
}
