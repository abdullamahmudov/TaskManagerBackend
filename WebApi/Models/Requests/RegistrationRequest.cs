using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Models.Shared;

namespace WebApi.Models.Requests
{
    public class RegistrationRequest
    {
        /// <summary>
        /// Данные запроса
        /// </summary>
        public required RegistractionUser Data { get; set; }
    }
}