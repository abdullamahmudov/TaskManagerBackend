using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagerBase.Interfaces;
using TaskManagerBase.Models.Shared;
using WebApi.Models.Requests;
using WebApi.Models.Responses;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskManagementController : ControllerBase
    {
        private readonly ILogger<TaskManagementController> _logger;
        private readonly ITaskControll _taskControll;
        private readonly IUserControll _userControll;
        public TaskManagementController(ILogger<TaskManagementController> logger, ITaskControll taskControll, IUserControll userControll)
        {
            _logger = logger;
            _taskControll = taskControll;
            _userControll = userControll;
        }

        [HttpPut]
        [Route("AddTask")]
        [ProducesResponseType<AddTaskResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddTaskResponse>> AddTask(AddTaskRequest request)
        {
            if (!await _userControll.CkeckAuth(request.AuthKey))
            {
                return Unauthorized();
            }
            if (!await _taskControll.AddTask(request.Data))
            {
                return BadRequest();
            }
            return new AddTaskResponse { Data = true };
        }

        [HttpPut]
        [Route("ChangeTask")]
        [ProducesResponseType<ChangeTaskResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ChangeTaskResponse>> ChangeTask(ChangeTaskRequest request)
        {
            if (!await _userControll.CkeckAuth(request.AuthKey))
            {
                return Unauthorized();
            }
            var task = await _taskControll.ChangeTask(request.Data);
            if (task is null)
            {
                return BadRequest();
            }
            return new ChangeTaskResponse { Data = task };
        }

        [HttpPost]
        [Route("GetTasks")]
        [ProducesResponseType<GetTasksResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetTasksResponse>> GetTasks(GetTasksRequest request)
        {
            if (!await _userControll.CkeckAuth(request.AuthKey))
            {
                return Unauthorized();
            }
            var task = await _taskControll.GetTasks(request.Data);
            if (task is null)
            {
                return BadRequest();
            }
            return new GetTasksResponse { Data = task };
        }
        
        [HttpDelete]
        [Route("RemoveTask")]
        [ProducesResponseType<RemoveTaskResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RemoveTaskResponse>> RemoveTask(RemovTaskRequest request)
        {
            if (!await _userControll.CkeckAuth(request.AuthKey))
            {
                return Unauthorized();
            }
            if (!await _taskControll.RemoveTask(request.Data.Id))
            {
                return BadRequest();
            }
            return new RemoveTaskResponse { Data = true };
        }
    }
}