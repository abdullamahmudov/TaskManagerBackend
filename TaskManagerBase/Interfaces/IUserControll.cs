using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models.Shared;
using TaskManagerBase.Models;

namespace TaskManagerBase.Interfaces
{
    public interface IUserControll
    {
        Task<bool> AddUser(RegistractionUser user);
        Task<bool> RemoveUser(User user);
        Task<User> AuthUser(LogInUser user);
    }
}