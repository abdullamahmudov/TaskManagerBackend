using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;
using TaskManagerBase.Models.Shared;

namespace TaskManagerBase.Interfaces
{
    /// <summary>
    /// Компонент для контроля задач
    /// </summary>
    public interface ITaskControll
    {
        /// <summary>
        /// Добавление задачи
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<bool> AddTask(AddedTask task);
        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveTask(string id);
        /// <summary>
        /// Изменение задачи
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<CRMTask?> ChangeTask(ChangedTask task);
        /// <summary>
        /// Получение задач
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<CRMTask>> GetTasks(TaskFilter? filter);
    }
}