using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;
using TaskManagerBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DBLayer.Implementations.SQLite
{
    /// <inheritdoc/>
    public class TaskSQLite : ITaskLayer
    {
        private readonly ILogger<TaskSQLite> _logger;
        private readonly SQLiteDataBase _dbContext;
        public TaskSQLite(ILogger<TaskSQLite> logger, IDbContextFactory<SQLiteDataBase> _contextFactory)
        {
            _logger = logger;
            _dbContext = _contextFactory.CreateDbContext();
        }
        // public TaskSQLite(ILogger<TaskSQLite> logger, SQLiteDataBase dbContext)
        // {
        //     _logger = logger;
        //     _dbContext = dbContext;
        // }
        public async Task<bool> AddTask(CRMTask task)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == task.CreatorId);

                if (user is null) return false;

                task.Id = Guid.NewGuid();
                task.CreateDate = DateTimeOffset.UtcNow;
                task.Creator = user;
                await _dbContext.Tasks.AddAsync(task);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }

        public async Task<CRMTask?> GetTask(Guid id)
        {
            try
            {
                var task = await _dbContext.Tasks.FirstOrDefaultAsync((task) => task.Id == id, CancellationToken.None);
                if (task == null)
                {
                    return null;
                }

                return task;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return null;
            }
        }

        public async Task<List<CRMTask>> GetTasks(TaskFilter? filter)
        {
            try
            {
                if (filter is null || filter.Value == default)
                {
                    return await _dbContext.Tasks.ToListAsync();
                }

                Func<CRMTask, bool> queryFilter = (task) =>
                {
                    var result = true;
                    if (filter.Value.CreateDateFrom.HasValue)
                        result = task.CreateDate >= filter.Value.CreateDateFrom.Value;
                    if (!result)
                        return false;

                    if (filter.Value.CreateDateTo.HasValue)
                        result = task.CreateDate <= filter.Value.CreateDateTo.Value;
                    if (!result)
                        return false;

                    if (filter.Value.CompliteDateFrom.HasValue)
                        result = task.CompliteDate >= filter.Value.CompliteDateFrom.Value;
                    if (!result)
                        return false;

                    if (filter.Value.CompliteDateTo.HasValue)
                        result = task.CompliteDate <= filter.Value.CompliteDateTo.Value;
                    if (!result)
                        return false;

                    if (filter.Value.PlanCompliteDateFrom.HasValue)
                        result = task.PlanCompliteDate >= filter.Value.PlanCompliteDateFrom.Value;
                    if (!result)
                        return false;

                    if (filter.Value.PlanCompliteDateTo.HasValue)
                        result = task.PlanCompliteDate <= filter.Value.PlanCompliteDateTo.Value;
                    if (!result)
                        return false;

                    if (filter.Value.UserId.HasValue)
                        result = task.CreatorId == filter.Value.UserId.Value;
                    if (!result)
                        return false;

                    if (filter.Value.Status.HasValue)
                        result = (task.Status | filter.Value.Status.Value) != 0;
                    if (!result)
                        return false;

                    return true;
                };

                return new List<CRMTask>(_dbContext.Tasks.Where(queryFilter));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return new List<CRMTask>();
            }
        }

        public async Task<bool> RemoveTask(Guid id)
        {
            try
            {
                var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

                if (task is null) return false;

                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }

        public async Task<CRMTask?> UpdateTask(Guid id, CRMTask task)
        {
            try
            {
                var oldTask = await _dbContext.Tasks.FirstOrDefaultAsync((t) => t.Id == id);
                if (oldTask is null)
                {
                    return null;
                }
                if (task.Status.HasValue)
                {
                    oldTask.Status = task.Status.Value;
                }
                if (task.TimeToComplite.HasValue)
                {
                    oldTask.TimeToComplite = task.TimeToComplite.Value;
                }
                _dbContext.SaveChanges();
                return task;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return null;
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