using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;
using TaskManagerBase.Models.Shared;

namespace TaskManagerBase.Interfaces
{
    public interface ITaskCommentControll
    {
        Task<bool> AddComment(AddedTaskComment addedComment);
        Task<bool> RemoveComment(string id);
        Task<List<TaskComment>> GetComments(string taskId);
    }
}