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
    public class TaskControll : ITaskControll
    {
        private readonly ILogger<TaskControll> _logger;
        private readonly IDataBaseLayer _dataBaseLayer;
        private readonly Cache _cache;
        public TaskControll(ILogger<TaskControll> logger, IDataBaseLayer dataBaseLayer, Cache cache)
        {
            _logger = logger;
            _dataBaseLayer = dataBaseLayer;
            _cache = cache;
        }
        public async Task<bool> AddTask(AddedTask task)
        {
            return await _dataBaseLayer.TaskLayer.AddTask(new CRMTask
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                PlanCompliteDate = task.PlanCompliteDate,
                CreatorId = new Guid(task.Creator)
            });
        }

        public async Task<CRMTask?> ChangeTask(ChangedTask task)
        {
            return await _dataBaseLayer.TaskLayer.UpdateTask(new Guid(task.Id), new CRMTask
            {
                Status = task.Status,
                TimeToComplite = task.TimeToComplite,
            });
        }

        public async Task<List<CRMTask>> GetTasks(TaskFilter? filter)
        {
            return await _dataBaseLayer.TaskLayer.GetTasks(filter);
        }

        public async Task<bool> RemoveTask(string id)
        {
            return await _dataBaseLayer.TaskLayer.RemoveTask(new Guid(id));
        }
    }
}