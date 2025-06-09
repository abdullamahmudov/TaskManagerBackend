using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagerBase.Models;

namespace DBLayer.Implementations.SQLite
{
    /// <inheritdoc/>
    public class TaskCommentSQLite : ITaskCommentLayer
    {
        private readonly ILogger<TaskCommentSQLite> _logger;
        private readonly SQLiteDataBase _dbContext;
        public TaskCommentSQLite(ILogger<TaskCommentSQLite> logger, IDbContextFactory<SQLiteDataBase> _contextFactory)
        {
            _logger = logger;
            _dbContext = _contextFactory.CreateDbContext();
        }
        // public TaskCommentSQLite(ILogger<TaskCommentSQLite> logger, SQLiteDataBase dbContext)
        // {
        //     _logger = logger;
        //     _dbContext = dbContext;
        // }
        public async Task<bool> AddComment(TaskComment comment)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == comment.CreatorId);
                if (user is null) return false;
                var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == comment.TaskId);
                if (task is null) return false;
                comment.Id = Guid.NewGuid();
                comment.CreatorId = user.Id;
                comment.Creator = user;
                comment.TaskId = task.Id;
                comment.Task = task;
                await _dbContext.Comments.AddAsync(comment);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }

        public async Task<List<TaskComment>> GetComments(Guid taskId)
        {
            try
            {
                return await (from comment in _dbContext.Comments
                              where comment.TaskId == taskId
                              select comment).ToListAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return new List<TaskComment>();
            }
        }

        public async Task<bool> RemoveComment(Guid id)
        {
            try
            {
                var comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);

                if (comment is null) return false;

                _dbContext.Comments.Remove(comment);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;

                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
        }
    }
}