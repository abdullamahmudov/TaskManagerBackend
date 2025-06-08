using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models
{
    public class TaskComment
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public CRMTask? Task { get; set; }
        public Guid CreatorId { get; set; }
        public User? Creator { get; set; }
        public string? Text { get; set; }
    }
}