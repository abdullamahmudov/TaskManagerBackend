using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace DBLayer.Interfaces
{
    public interface ITaskCommentLayer
    {
        Task<bool> AddComment(TaskComment comment);
        Task<bool> RemoveComment(Guid id);
        Task<List<TaskComment>> GetComments(Guid taskId);
    }
}