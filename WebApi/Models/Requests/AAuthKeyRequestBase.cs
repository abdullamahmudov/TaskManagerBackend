using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Requests
{
    public abstract class AAuthKeyRequestBase<TData>
    {
        /// <summary>
        /// Ключ авторизации
        /// </summary>
        public required string AuthKey { get; set; }
        /// <summary>
        /// Данные запроса
        /// </summary>
        public required TData Data { get; set; }
    }
}