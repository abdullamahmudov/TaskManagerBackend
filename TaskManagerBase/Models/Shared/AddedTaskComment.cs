using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models.Shared
{
    public class AddedTaskComment
    {
        public required string TaskId { get; set; }
        public required string CreatorId { get; set; }
        public required string Text { get; set; }
    }
}