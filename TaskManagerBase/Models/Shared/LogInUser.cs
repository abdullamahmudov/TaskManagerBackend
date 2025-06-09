using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models.Shared
{
    public class LogInUser
    {
        /// <summary>
        /// Логин
        /// </summary>
        public required string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public required string Password { get; set; }
    }
}