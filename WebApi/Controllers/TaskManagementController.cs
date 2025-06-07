using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskManagementController : ControllerBase
    {
        ILogger<TaskManagementController> _logger;
        public TaskManagementController(ILogger<TaskManagementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult TestMethod()
        {
            return Ok();
        }
    }
}