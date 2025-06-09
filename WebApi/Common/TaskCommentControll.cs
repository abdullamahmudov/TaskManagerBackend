using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;
using TaskManagerBase.Interfaces;
using TaskManagerBase.Methods;
using TaskManagerBase.Models;
using TaskManagerBase.Models.Shared;

namespace WebApi.Common
{
    /// <inheritdoc/>
    public class TaskCommentControll : ITaskCommentControll
    {
        private readonly ILogger<TaskCommentControll> _logger;
        private readonly IDataBaseLayer _dataBaseLayer;
        private readonly Cache _cache;
        public TaskCommentControll(ILogger<TaskCommentControll> logger, IDataBaseLayer dataBaseLayer, Cache cache)
        {
            _logger = logger;
            _dataBaseLayer = dataBaseLayer;
            _cache = cache;
        }
        public async Task<bool> AddComment(AddedTaskComment addedComment)
        {
            return await _dataBaseLayer.CommentLayer.AddComment(new TaskComment
            {
                TaskId = new Guid(addedComment.TaskId),
                CreatorId = new Guid(addedComment.CreatorId),
                Text = addedComment.Text,
            });
        }

        public async Task<List<TaskComment>> GetComments(string taskId)
        {
            if (!_cache.CommentsByTaskId.TryGetValue(taskId, out var comments))
            {
                comments = await _dataBaseLayer.CommentLayer.GetComments(new Guid(taskId));
                if (comments is null || comments.Count == 0)
                    return new List<TaskComment>();

                _cache.CommentsByTaskId.Add(taskId, comments);
            }
            return comments;
        }

        public async Task<bool> RemoveComment(string id)
        {
            return await _dataBaseLayer.CommentLayer.RemoveComment(new Guid(id));
        }
    }
}