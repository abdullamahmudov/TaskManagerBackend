using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBLayer.Interfaces
{
    /// <summary>
    /// Слой взаимодействия с данными
    /// </summary>
    public interface IDataBaseLayer : IDisposable
    {
        /// <summary>
        /// Слой данных пользователей
        /// </summary>
        IUserLayer UserLayer { get; }
        /// <summary>
        /// Слой данных задач
        /// </summary>
        ITaskLayer TaskLayer { get; }
        /// <summary>
        /// Слой данных комментариев задач
        /// </summary>
        ITaskCommentLayer CommentLayer { get; }
    }
}