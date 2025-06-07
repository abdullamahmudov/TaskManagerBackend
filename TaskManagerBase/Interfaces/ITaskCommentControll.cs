using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace TaskManagerBase.Interfaces
{
    public interface ITaskCommentControll
    {
        bool AddComment(CRMTask task, User user, string comment);
    }
}