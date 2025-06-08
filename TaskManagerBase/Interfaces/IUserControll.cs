using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models.Shared;
using TaskManagerBase.Models;

namespace TaskManagerBase.Interfaces
{
    public interface IUserControll : IDisposable
    {
        Task<bool> RegistrationUser(RegistractionUser user);
        Task<bool> RemoveUser(string id);
        Task<User?> LogIn(LogInUser user);
        Task<bool> CkeckAuth(string authKey);
    }
}