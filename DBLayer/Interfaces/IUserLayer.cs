using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace DBLayer.Interfaces
{
    public interface IUserLayer : IDisposable
    {
        Task<bool> AddUser(User user);
        Task<bool> RemoveUser(Guid id);
        Task<User?> GetUser(Guid id);
        Task<User?> GetUserByLogin(string login);
        Task<User?> GetUserByAuthKey(string authKey);
        Task<string?> AuthUser(Guid id);
    }
}