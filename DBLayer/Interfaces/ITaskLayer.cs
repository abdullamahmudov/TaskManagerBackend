using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace DBLayer.Interfaces
{
    public interface ITaskLayer
    {
        Task<bool> AddTask(CRMTask task);
        Task<bool> RemoveTask(Guid id);
        Task<CRMTask?> GetTask(Guid id);
        Task<List<CRMTask>> GetTasks(TaskFilter? filter);
        Task<bool> UpdateTask(Guid id, CRMTask task);
    }
}