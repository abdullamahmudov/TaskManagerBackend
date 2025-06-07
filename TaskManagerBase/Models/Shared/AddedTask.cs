using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Enums;

namespace TaskManagerBase.Models.Shared
{
    public class AddedTask
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public CRMTaskStatus Status { get; set; }
        public DateTimeOffset? PlanCompliteDate { get; set; }
        public required string Creator { get; set; }
    }
}