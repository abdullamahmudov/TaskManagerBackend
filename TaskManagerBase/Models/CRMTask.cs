using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Enums;

namespace TaskManagerBase.Models
{
    public class CRMTask
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public DateTimeOffset CreateDate { get; set; }
        /// <summary>
        /// Дата заверщения задачи
        /// </summary>
        public DateTimeOffset? CompliteDate { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public CRMTaskStatus? Status { get; set; }
        /// <summary>
        /// Плановая дата/время завершения задачи
        /// </summary>
        public DateTimeOffset? PlanCompliteDate { get; set; }
        /// <summary>
        /// Фактическое время завершения задачи
        /// </summary>
        public ulong? TimeToComplite { get; set; }
        /// <summary>
        /// Идентификатор автора
        /// </summary>
        public Guid CreatorId { get; set; }
        /// <summary>
        /// Автор
        /// </summary>
        public User? Creator { get; set; }
    }
}