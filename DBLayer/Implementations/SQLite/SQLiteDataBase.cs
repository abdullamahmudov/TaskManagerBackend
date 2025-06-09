using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;
using TaskManagerBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Implementations.SQLite
{
    /// <summary>
    /// Контекст для взаимодействия с СУБД SQLite
    /// </summary>
    public class SQLiteDataBase : DbContext, IDataBase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CRMTask> Tasks { get; set; }
        public DbSet<TaskComment> Comments { get; set; }

        public SQLiteDataBase(DbContextOptions<SQLiteDataBase> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique(true);
        }
    }
}