using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Implementations.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using TaskManagerBase.Implementations;
using TaskManagerBase.Interfaces;
using WebApi.Common;

namespace MSTestProject.Common
{
    public class DBConnector : IDisposable
    {
        private const string INITIOLIZE_SQLITE_DIRECTORY_ENVIRONMENT = "D:\\Work\\Custom\\TaskManager\\DB";
        
        public IUserControll UserControll { get; private set; }

        public DBConnector()
        {
            var connectionString = string.Concat("FileName=", INITIOLIZE_SQLITE_DIRECTORY_ENVIRONMENT, "/TaskManager.db");
            var contextOptions = new DbContextOptionsBuilder<SQLiteDataBase>().UseSqlite(connectionString).Options;
            var dbContextFactory = new DbContextFactory<SQLiteDataBase>(null, contextOptions, new DbContextFactorySource<SQLiteDataBase>());
            using (var dataBase = new SQLiteDataBase(contextOptions))
            {
                dataBase.Database.Migrate();
            }

            var loggerFactory = LoggerFactory.Create((builder) => builder.AddConsole());
            var userLayer = new UserSQLite(loggerFactory.CreateLogger<UserSQLite>(), dbContextFactory);
            var taskLayer = new TaskSQLite(loggerFactory.CreateLogger<TaskSQLite>(), dbContextFactory);
            var commentLayer = new TaskCommentSQLite(loggerFactory.CreateLogger<TaskCommentSQLite>(), dbContextFactory);
            var dataBaseLayer = new SQLiteDBLayer(userLayer, taskLayer, commentLayer);
            UserControll = new UserControll(loggerFactory.CreateLogger<UserControll>(), dataBaseLayer, new DefaultCripto(), new TaskManagerBase.Methods.Cache());
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
                    UserControll.Dispose();
                }
            }
        }
    }
}