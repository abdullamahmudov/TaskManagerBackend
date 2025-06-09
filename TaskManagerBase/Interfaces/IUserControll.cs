using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models.Shared;
using TaskManagerBase.Models;

namespace TaskManagerBase.Interfaces
{
    /// <summary>
    /// Компонент для контроля пользователей
    /// </summary>
    public interface IUserControll : IDisposable
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> RegistrationUser(RegistractionUser user);
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveUser(string id);
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User?> LogIn(LogInUser user);
        /// <summary>
        /// Проверка авторизации
        /// </summary>
        /// <param name="authKey"></param>
        /// <returns></returns>
        Task<bool> CkeckAuth(string authKey);
    }
}