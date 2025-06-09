using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models
{
    public class TaskComment
    {
        /// <summary>
        /// Идентификатор комментария
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid TaskId { get; set; }
        /// <summary>
        /// Задача
        /// </summary>
        public CRMTask? Task { get; set; }
        /// <summary>
        /// Идентификатор автора
        /// </summary>
        public Guid CreatorId { get; set; }
        /// <summary>
        /// Автор
        /// </summary>
        /// <value></value>
        public User? Creator { get; set; }
        /// <summary>
        /// Текст
        /// </summary>
        public string? Text { get; set; }
    }
}