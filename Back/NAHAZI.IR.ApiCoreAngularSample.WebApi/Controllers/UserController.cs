using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAHAZI.IR.ApiCoreAngularSample.WebApi.Model.DomainClasses;
using NAHAZI.IR.ApiCoreAngularSample.WebApi.Model.User;
using NAHAZI.IR.ApiCoreAngularSample.WebApi.Services;

namespace NAHAZI.IR.ApiCoreAngularSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields

        private readonly IConfiguration _config;
        private readonly IUserManagementService _userManagementService;



        #endregion

        #region Ctor

        public UserController(IConfiguration config, IUserManagementService userManagementService)
        {
            _config = config;
            _userManagementService = userManagementService;
        }

        #endregion

        #region Actions

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginModel userLogin)
        {
            var result = _userManagementService.Login(userLogin);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            _userManagementService.AddUser(user);
            return Ok();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
