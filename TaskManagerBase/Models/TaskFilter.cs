using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Enums;

namespace TaskManagerBase.Models
{
    public struct TaskFilter
    {
        /// <summary>
        /// Дата создания От
        /// </summary>
        public DateTimeOffset? CreateDateFrom { get; set; }
        /// <summary>
        /// Дата создания До
        /// </summary>
        public DateTimeOffset? CreateDateTo { get; set; }

        /// <summary>
        /// Дата завршения От
        /// </summary>
        public DateTimeOffset? CompliteDateFrom { get; set; }
        /// <summary>
        /// Дата завршения До
        /// </summary>
        public DateTimeOffset? CompliteDateTo { get; set; }

        /// <summary>
        /// Плановая дата завршения От
        /// </summary>
        public DateTimeOffset? PlanCompliteDateFrom { get; set; }
        /// <summary>
        /// Плановая дата завршения До
        /// </summary>
        public DateTimeOffset? PlanCompliteDateTo { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Статусы
        /// </summary>
        public CRMTaskStatus? Status { get; set; }

        public static bool operator ==(TaskFilter ob1, TaskFilter obj2) =>
        ob1.CreateDateFrom == obj2.CreateDateFrom && ob1.CreateDateTo == obj2.CreateDateTo &&
        ob1.CompliteDateFrom == obj2.CompliteDateFrom && ob1.CompliteDateTo == obj2.CompliteDateTo &&
        ob1.PlanCompliteDateFrom == obj2.PlanCompliteDateFrom && ob1.PlanCompliteDateTo == obj2.PlanCompliteDateTo &&
        ob1.UserId == obj2.UserId && ob1.Status == obj2.Status;

        public static bool operator !=(TaskFilter ob1, TaskFilter obj2) => ob1 == obj2 ? false : true;
    }
}