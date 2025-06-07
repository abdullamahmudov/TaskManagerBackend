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
    public class TaskCommentSQLite : ITaskCommentLayer
    {
        private readonly ILogger<TaskCommentSQLite> _logger;
        private readonly SQLiteDataBase _dbContext;
        public TaskCommentSQLite(ILogger<TaskCommentSQLite> logger, IDbContextFactory<SQLiteDataBase> _contextFactory)
        {
            _logger = logger;
            _dbContext = _contextFactory.CreateDbContext();
        }
        public async Task<bool> AddComment(TaskComment comment)
        {
            try
            {
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
                _dbContext.Comments.Remove(new TaskComment { Id = id });
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }
    }
}