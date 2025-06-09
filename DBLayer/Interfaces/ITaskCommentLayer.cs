using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace DBLayer.Interfaces
{
    /// <summary>
    /// Слой взаимодействия с данными комментариев задач
    /// </summary>
    public interface ITaskCommentLayer : IDisposable
    {
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task<bool> AddComment(TaskComment comment);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveComment(Guid id);
        /// <summary>
        /// Получение
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<List<TaskComment>> GetComments(Guid taskId);
    }
}