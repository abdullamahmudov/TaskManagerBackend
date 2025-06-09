using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManagerBase.Interfaces;
using WebApi.Models.Requests;
using WebApi.Models.Responses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private ILogger<UserManagementController> _logger;
        private IUserControll _userControll;
        public UserManagementController(ILogger<UserManagementController> logger, IUserControll userControll)
        {
            _logger = logger;
            _userControll = userControll;
        }

        [HttpPut]
        [Route("Registration")]
        [ProducesResponseType<RegistrationResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegistrationResponse>> Registration(RegistrationRequest request)
        {
            if (!await _userControll.RegistrationUser(request.Data))
                return BadRequest();
            return new RegistrationResponse { Data = true };
        }

        [HttpPost]
        [Route("LogIn")]
        [ProducesResponseType<LogInResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LogInResponse>> LogIn(LogInRequest request)
        {
            var user = await _userControll.LogIn(request.Data);
            if (user is null)
                return Unauthorized();
            return new LogInResponse { Data = user };
        }
    }
}