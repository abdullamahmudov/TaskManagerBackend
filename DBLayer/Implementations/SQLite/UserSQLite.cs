using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;
using TaskManagerBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DBLayer.Implementations.SQLite
{
    public class UserSQLite : IUserLayer
    {
        private readonly ILogger<UserSQLite> _logger;
        private readonly SQLiteDataBase _dbContext;
        public UserSQLite(ILogger<UserSQLite> logger, IDbContextFactory<SQLiteDataBase> _contextFactory)
        {
            _logger = logger;
            _dbContext = _contextFactory.CreateDbContext();
        }
        public async Task<bool> AddUser(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }

        public async Task<string?> AuthUser(string name, string password)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync((user) => user.Name == name && user.Password == password, CancellationToken.None);
                if (user == null)
                {
                    return null;
                }

                var authKey = Guid.NewGuid().ToString();
                user.AuthKey = authKey;
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return authKey;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return null;
            }
        }

        public async Task<User?> GetUser(Guid id)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync((user) => user.Id == id, CancellationToken.None);
                if (user == null)
                {
                    return null;
                }

                return user;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return null;
            }
        }

        public async Task<User?> GetUser(string authKey)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync((user) => user.AuthKey == authKey, CancellationToken.None);
                if (user == null)
                {
                    return null;
                }

                return user;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return null;
            }
        }

        public async Task<bool> RemoveUser(Guid id)
        {
            try
            {
                _dbContext.Users.Remove(new User { Id = id });
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }
    }
}