using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        ILogger<UserManagementController> _logger;
        public UserManagementController(ILogger<UserManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return Ok();
        }
    }
}