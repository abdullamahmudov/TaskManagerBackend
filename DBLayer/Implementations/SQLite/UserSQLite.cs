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
        // public UserSQLite(ILogger<UserSQLite> logger, SQLiteDataBase dbContext)
        // {
        //     _logger = logger;
        //     _dbContext = dbContext;
        // }
        public async Task<bool> AddUser(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                await _dbContext.Users.AddAsync(user);
                var count = _dbContext.SaveChanges();
                return count == 1;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
        }

        public async Task<string?> AuthUser(Guid id)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync((user) => user.Id == id, CancellationToken.None);
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

        public async Task<User?> GetUserByAuthKey(string authKey)
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

        public async Task<User?> GetUserByLogin(string login)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync((user) => user.Login == login, CancellationToken.None);
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
                var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

                if (user is null) return false;
                
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(null, ex);
                return false;
            }
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
                    _dbContext.Dispose();
                }
            }
        }
    }
}