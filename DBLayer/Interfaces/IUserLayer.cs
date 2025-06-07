using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace DBLayer.Interfaces
{
    public interface IUserLayer
    {
        Task<bool> AddUser(User user);
        Task<bool> RemoveUser(Guid id);
        Task<User?> GetUser(Guid id);
        Task<User?> GetUser(string authKey);
        Task<string?> AuthUser(string name, string password);
    }
}