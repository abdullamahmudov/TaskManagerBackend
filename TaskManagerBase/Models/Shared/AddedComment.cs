using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models.Shared
{
    public class AddedComment
    {
        public required string TaskId { get; set; }
        public required string Creator { get; set; }
        public required string Text { get; set; }
    }
}