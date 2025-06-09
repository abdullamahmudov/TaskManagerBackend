using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models;

namespace DBLayer.Interfaces
{
    /// <summary>
    /// Слой взаимодействия с данными пользователей
    /// </summary>
    public interface IUserLayer : IDisposable
    {
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> AddUser(User user);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveUser(Guid id);
        /// <summary>
        /// Получение
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User?> GetUser(Guid id);
        /// <summary>
        /// Получение по логину
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<User?> GetUserByLogin(string login);
        /// <summary>
        /// Получение по ключу авторизации
        /// </summary>
        /// <param name="authKey"></param>
        /// <returns></returns>
        Task<User?> GetUserByAuthKey(string authKey);
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string?> AuthUser(Guid id);
    }
}