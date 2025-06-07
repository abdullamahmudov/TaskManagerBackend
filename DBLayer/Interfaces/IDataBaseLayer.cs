using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBLayer.Interfaces
{
    public interface IDataBaseLayer
    {
        IUserLayer UserLayer { get; }
        ITaskLayer TaskLayer { get; }
        ITaskCommentLayer CommentLayer { get; }
    }
}