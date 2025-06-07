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
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string? Text { get; set; }
    }
}