using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;

namespace DBLayer.Implementations.SQLite
{
    /// <inheritdoc/>
    public class SQLiteDBLayer : IDataBaseLayer
    {
        public IUserLayer UserLayer { get; private set; }

        public ITaskLayer TaskLayer { get; private set; }

        public ITaskCommentLayer CommentLayer { get; private set; }

        public SQLiteDBLayer(IUserLayer userLayer, ITaskLayer taskLayer, ITaskCommentLayer commentLayer)
        {
            UserLayer = userLayer;
            TaskLayer = taskLayer;
            CommentLayer = commentLayer;
        }

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;

                if (disposing)
                {
                    UserLayer.Dispose();
                    TaskLayer.Dispose();
                    CommentLayer.Dispose();
                }
            }
        }
    }
}