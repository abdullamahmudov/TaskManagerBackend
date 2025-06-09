using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models.Shared
{
    public class RemovedTask
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public required string Id { get; set; }
    }
}