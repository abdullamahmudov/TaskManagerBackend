using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;
using TaskManagerBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Implementations.SQLite
{
    public class SQLiteDataBase : DbContext, IDataBase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CRMTask> Tasks { get; set; }
        public DbSet<TaskComment> Comments { get; set; }

        public SQLiteDataBase(DbContextOptions<SQLiteDataBase> options) : base(options)
        {
        }
    }
}