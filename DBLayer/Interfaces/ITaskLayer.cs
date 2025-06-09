using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace DBLayer.Interfaces
{
    /// <summary>
    /// Слой взаимодействия с данными задач
    /// </summary>
    public interface ITaskLayer : IDisposable
    {
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<bool> AddTask(CRMTask task);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveTask(Guid id);
        /// <summary>
        /// Получение
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CRMTask?> GetTask(Guid id);
        /// <summary>
        /// Получение
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<CRMTask>> GetTasks(TaskFilter? filter);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<CRMTask?> UpdateTask(Guid id, CRMTask task);
    }
}