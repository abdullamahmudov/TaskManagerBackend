using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Enums;

namespace TaskManagerBase.Models
{
    public class TaskFilter
    {
        public DateTimeOffset? CreateDateFrom { get; private set; }
        public DateTimeOffset? CreateDateTo { get; private set; }

        public DateTimeOffset? CompliteDateFrom { get; private set; }
        public DateTimeOffset? CompliteDateTo { get; private set; }

        public DateTimeOffset? PlanCompliteDateFrom { get; private set; }
        public DateTimeOffset? PlanCompliteDateTo { get; private set; }

        public User? User { get; private set; }
        public CRMTaskStatus? Status { get; private set; }
    }
}