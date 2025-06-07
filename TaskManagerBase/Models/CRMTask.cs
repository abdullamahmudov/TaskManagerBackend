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
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? CompliteDate { get; set; }
        public CRMTaskStatus? Status { get; set; }
        public DateTimeOffset? PlanCompliteDate { get; set; }
        public ulong? TimeToComplite { get; set; }
        public Guid CreatorId { get; set; }
        public User? Creator { get; set; }
    }
}