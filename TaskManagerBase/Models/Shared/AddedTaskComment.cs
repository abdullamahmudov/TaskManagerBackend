using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models.Shared
{
    public class AddedTaskComment
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public required string TaskId { get; set; }
        /// <summary>
        /// Идентификатор автора
        /// </summary>
        public required string CreatorId { get; set; }
        /// <summary>
        /// Текст
        /// </summary>
        public required string Text { get; set; }
    }
}