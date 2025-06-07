using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Implementations.SQLite;
using DBLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DBLayer.Common
{
    public static class InitiolizeSQLite
    {
        private const string InitiolizeSQLiteDirectoryEnvironment = "INITIOLIZE_SQLITE_DIRECTORY";
        public static void InitiolizeSQLiteServices(this IServiceCollection services)
        {
            var directory = Environment.GetEnvironmentVariable(InitiolizeSQLiteDirectoryEnvironment);
            if (directory is null || !Directory.Exists(directory))
            {
                throw new Exception("Incorrected \"INITIOLIZE_SQLITE_DIRECTORY\" value!");
            }
            var connectionString = string.Concat("FileName=", directory, "/TaskManager.db");
            var contextOptions = new DbContextOptionsBuilder<SQLiteDataBase>().UseSqlite(connectionString).Options;
            using (var db = new SQLiteDataBase(contextOptions))
            {
                db.Database.Migrate();
            }

            services.AddDbContextFactory<SQLiteDataBase>((optionsBuilder) => { optionsBuilder.UseSqlite(connectionString); });
            services.AddScoped<IUserLayer, UserSQLite>();
            services.AddScoped<ITaskLayer, TaskSQLite>();
            services.AddScoped<ITaskCommentLayer, TaskCommentSQLite>();
            services.AddScoped<IDataBaseLayer, SQLiteDBLayer>();
        }
    }
}