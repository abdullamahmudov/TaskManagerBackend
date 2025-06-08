using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Enums;

namespace TaskManagerBase.Models
{
    public struct TaskFilter
    {
        public DateTimeOffset? CreateDateFrom { get; set; }
        public DateTimeOffset? CreateDateTo { get; set; }

        public DateTimeOffset? CompliteDateFrom { get; set; }
        public DateTimeOffset? CompliteDateTo { get; set; }

        public DateTimeOffset? PlanCompliteDateFrom { get; set; }
        public DateTimeOffset? PlanCompliteDateTo { get; set; }

        public Guid? UserId { get; set; }
        public CRMTaskStatus? Status { get; set; }

        public static bool operator ==(TaskFilter ob1, TaskFilter obj2) =>
        ob1.CreateDateFrom == obj2.CreateDateFrom && ob1.CreateDateTo == obj2.CreateDateTo &&
        ob1.CompliteDateFrom == obj2.CompliteDateFrom && ob1.CompliteDateTo == obj2.CompliteDateTo &&
        ob1.PlanCompliteDateFrom == obj2.PlanCompliteDateFrom && ob1.PlanCompliteDateTo == obj2.PlanCompliteDateTo &&
        ob1.UserId == obj2.UserId && ob1.Status == obj2.Status;

        public static bool operator !=(TaskFilter ob1, TaskFilter obj2) => ob1 == obj2 ? false : true;
    }
}