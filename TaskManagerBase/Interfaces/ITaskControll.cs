using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;
using TaskManagerBase.Models.Shared;

namespace TaskManagerBase.Interfaces
{
    public interface ITaskControll
    {
        Task<bool> AddTask(AddedTask task);
        Task<bool> RemoveTask(string id);
        Task<CRMTask?> ChangeTask(ChangedTask task);
        Task<List<CRMTask>> GetTasks(TaskFilter filter);
    }
}