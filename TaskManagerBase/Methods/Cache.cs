using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace TaskManagerBase.Methods
{
    /// <summary>
    /// Кеша данных
    /// </summary>
    public class Cache
    {
        public Dictionary<string, User> UsersByLogin { get; private set; } = new Dictionary<string, User>();
        public Dictionary<string, User> UsersByAuthKey { get; private set; } = new Dictionary<string, User>();

        public Dictionary<string, CRMTask> TasksById { get; private set; } = new Dictionary<string, CRMTask>();
        public Dictionary<TaskFilter, List<CRMTask>> TasksByFilter { get; private set; } = new Dictionary<TaskFilter, List<CRMTask>>();

        public Dictionary<string, List<TaskComment>> CommentsByTaskId { get; private set; } = new Dictionary<string, List<TaskComment>>();
    }
}