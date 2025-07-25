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
    public class TaskCommentManagementController : ControllerBase
    {
        private readonly ILogger<TaskManagementController> _logger;
        private readonly ITaskCommentControll _taskCommentControll;
        private readonly IUserControll _userControll;
        public TaskCommentManagementController(ILogger<TaskManagementController> logger, ITaskCommentControll taskCommentControll, IUserControll userControll)
        {
            _logger = logger;
            _taskCommentControll = taskCommentControll;
            _userControll = userControll;
        }

        /// <summary>
        /// Добавление комментария
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AddComment")]
        [ProducesResponseType<AddTaskCommentResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddTaskResponse>> AddComment(AddTaskCommentRequest request)
        {
            if (!await _userControll.CkeckAuth(request.AuthKey))
            {
                return Unauthorized();
            }
            if (!await _taskCommentControll.AddComment(request.Data))
            {
                return BadRequest();
            }
            return new AddTaskResponse { Data = true };
        }

        /// <summary>
        /// Получение комментариев
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetComments")]
        [ProducesResponseType<GetCommentsResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCommentsResponse>> GetComments(GetCommentsRequest request)
        {
            if (!await _userControll.CkeckAuth(request.AuthKey))
            {
                return Unauthorized();
            }
            var comments = await _taskCommentControll.GetComments(request.Data);
            if (comments is null)
            {
                return BadRequest();
            }
            return new GetCommentsResponse { Data = comments };
        }
    }
}