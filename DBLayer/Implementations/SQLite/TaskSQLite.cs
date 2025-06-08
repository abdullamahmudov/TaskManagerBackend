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
                if (filter == null)
                {
                    return await _dbContext.Tasks.ToListAsync();
                }

                switch (filter)
                {
                    case TaskFilter f1 when f1.CreateDateFrom.HasValue && f1.CreateDateTo.HasValue &&
                    f1.CompliteDateFrom.HasValue && f1.CompliteDateTo.HasValue &&
                    f1.PlanCompliteDateFrom.HasValue && f1.PlanCompliteDateTo.HasValue &&
                    f1.User is not null && f1.Status.HasValue:
                        return await (from task in _dbContext.Tasks
                                      where task.CompliteDate != null && task.PlanCompliteDate != null && task.Status.HasValue && ((task.Status | f1.Status.Value) != 0) &&
                        f1.CreateDateFrom <= task.CreateDate && f1.CreateDateTo >= task.CreateDate &&
                        f1.CompliteDateFrom <= task.CompliteDate && f1.CompliteDateTo >= task.CompliteDate &&
                        f1.PlanCompliteDateFrom <= task.PlanCompliteDate && f1.PlanCompliteDateTo <= task.PlanCompliteDate &&
                        f1.User == task.Creator
                                      select task).ToListAsync();
                    case TaskFilter f2 when f2.CreateDateFrom.HasValue && f2.CreateDateTo.HasValue &&
                    f2.CompliteDateFrom.HasValue && f2.CompliteDateTo.HasValue &&
                    f2.PlanCompliteDateFrom.HasValue && f2.PlanCompliteDateTo.HasValue &&
                    f2.User is not null:
                        return await (from task in _dbContext.Tasks
                                      where task.CompliteDate != null && task.PlanCompliteDate != null &&
                        f2.CreateDateFrom <= task.CreateDate && f2.CreateDateTo >= task.CreateDate &&
                        f2.CompliteDateFrom <= task.CompliteDate && f2.CompliteDateTo >= task.CompliteDate &&
                        f2.PlanCompliteDateFrom <= task.PlanCompliteDate && f2.PlanCompliteDateTo <= task.PlanCompliteDate &&
                        f2.User == task.Creator
                                      select task).ToListAsync();
                    case TaskFilter f3 when f3.CreateDateFrom.HasValue && f3.CreateDateTo.HasValue &&
                    f3.CompliteDateFrom.HasValue && f3.CompliteDateTo.HasValue &&
                    f3.PlanCompliteDateFrom.HasValue && f3.PlanCompliteDateTo.HasValue:
                        return await (from task in _dbContext.Tasks
                                      where task.CompliteDate != null && task.PlanCompliteDate != null &&
                        f3.CreateDateFrom <= task.CreateDate && f3.CreateDateTo >= task.CreateDate &&
                        f3.CompliteDateFrom <= task.CompliteDate && f3.CompliteDateTo >= task.CompliteDate &&
                        f3.PlanCompliteDateFrom <= task.PlanCompliteDate && f3.PlanCompliteDateTo <= task.PlanCompliteDate
                                      select task).ToListAsync();
                    case TaskFilter f4 when f4.CreateDateFrom.HasValue && f4.CreateDateTo.HasValue &&
                    f4.CompliteDateFrom.HasValue && f4.CompliteDateTo.HasValue &&
                    f4.PlanCompliteDateFrom.HasValue:
                        return await (from task in _dbContext.Tasks
                                      where task.CompliteDate != null && task.PlanCompliteDate != null &&
                        f4.CreateDateFrom <= task.CreateDate && f4.CreateDateTo >= task.CreateDate &&
                        f4.CompliteDateFrom <= task.CompliteDate && f4.CompliteDateTo >= task.CompliteDate &&
                        f4.PlanCompliteDateFrom <= task.PlanCompliteDate
                                      select task).ToListAsync();
                    case TaskFilter f5 when f5.CreateDateFrom.HasValue && f5.CreateDateTo.HasValue &&
                    f5.CompliteDateFrom.HasValue && f5.CompliteDateTo.HasValue:
                        return await (from task in _dbContext.Tasks
                                      where task.CompliteDate != null &&
                        f5.CreateDateFrom <= task.CreateDate && f5.CreateDateTo >= task.CreateDate &&
                        f5.CompliteDateFrom <= task.CompliteDate && f5.CompliteDateTo >= task.CompliteDate
                                      select task).ToListAsync();
                    case TaskFilter f6 when f6.CreateDateFrom.HasValue && f6.CreateDateTo.HasValue &&
                    f6.CompliteDateFrom.HasValue:
                        return await (from task in _dbContext.Tasks
                                      where task.CompliteDate != null &&
                        f6.CreateDateFrom <= task.CreateDate && f6.CreateDateTo >= task.CreateDate &&
                        f6.CompliteDateFrom <= task.CompliteDate
                                      select task).ToListAsync();
                    case TaskFilter f7 when f7.CreateDateFrom.HasValue && f7.CreateDateTo.HasValue:
                        return await (from task in _dbContext.Tasks
                                      where f7.CreateDateFrom <= task.CreateDate && f7.CreateDateTo >= task.CreateDate
                                      select task).ToListAsync();
                    case TaskFilter f8 when f8.CreateDateFrom.HasValue:
                        return await (from task in _dbContext.Tasks
                                      where f8.CreateDateFrom <= task.CreateDate
                                      select task).ToListAsync();
                }
                return new List<CRMTask>();
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

                task.Id = id;
                task.Title = oldTask.Title;
                task.Description = oldTask.Description;
                task.CreateDate = oldTask.CreateDate;
                task.CompliteDate = oldTask.CompliteDate;
                if (!task.Status.HasValue && oldTask.Status.HasValue)
                {
                    task.Status = oldTask.Status.Value;
                }
                task.PlanCompliteDate = oldTask.PlanCompliteDate;
                if (!task.TimeToComplite.HasValue && oldTask.TimeToComplite.HasValue)
                {
                    task.TimeToComplite = oldTask.TimeToComplite.Value;
                }
                task.Creator = oldTask.Creator;
                _dbContext.Tasks.Update(task);
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