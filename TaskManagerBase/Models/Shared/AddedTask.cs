using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Enums;

namespace TaskManagerBase.Models.Shared
{
    public class AddedTask
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public CRMTaskStatus Status { get; set; }
        /// <summary>
        /// Плановая дата/время завершения задачи
        /// </summary>
        public DateTimeOffset? PlanCompliteDate { get; set; }
        /// <summary>
        /// Автор
        /// </summary>
        public required string Creator { get; set; }
    }
}