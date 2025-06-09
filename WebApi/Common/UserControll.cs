using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Interfaces;
using TaskManagerBase.Interfaces;
using TaskManagerBase.Methods;
using TaskManagerBase.Models;
using TaskManagerBase.Models.Shared;

namespace WebApi.Common
{
    /// <inheritdoc/>
    public class UserControll : IUserControll
    {
        private readonly ILogger<UserControll> _logger;
        private readonly IDataBaseLayer _dataBaseLayer;
        private readonly ICripto _cripto;
        private readonly Cache _cache;
        public UserControll(ILogger<UserControll> logger, IDataBaseLayer dataBaseLayer, ICripto cripto, Cache cache)
        {
            _logger = logger;
            _dataBaseLayer = dataBaseLayer;
            _cripto = cripto;
            _cache = cache;
        }

        public async Task<bool> RegistrationUser(RegistractionUser user)
        {
            return await _dataBaseLayer.UserLayer.AddUser(new User { Login = user.Login, Name = user.Name, Password = _cripto.Compute(user.Password) });
        }

        public async Task<User?> LogIn(LogInUser user)
        {
            if (!_cache.UsersByLogin.TryGetValue(user.Login, out var savedUser))
            {
                savedUser = await _dataBaseLayer.UserLayer.GetUserByLogin(user.Login);

                if (savedUser is null || savedUser.Password is null) return null;

                _cache.UsersByLogin.Add(user.Login, savedUser);
            }
            if (savedUser.Password is null) return null;

            if (!_cripto.Verify(user.Password, savedUser.Password)) return null;

            var authKey = await _dataBaseLayer.UserLayer.AuthUser(savedUser.Id);

            return new User { Id = savedUser.Id, Name = savedUser.Name, AuthKey = authKey };
        }

        public async Task<bool> CkeckAuth(string authKey)
        {
            if (!_cache.UsersByAuthKey.TryGetValue(authKey, out var savedUser))
            {
                savedUser = await _dataBaseLayer.UserLayer.GetUserByAuthKey(authKey);

                if (savedUser is null) return false;

                _cache.UsersByAuthKey.Add(authKey, savedUser);
            }

            return true;
        }

        public async Task<bool> RemoveUser(string id)
        {
            return await _dataBaseLayer.UserLayer.RemoveUser(new Guid(id));
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
                    _dataBaseLayer.Dispose();
                }
            }
        }
    }
}