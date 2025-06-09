using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models.Responses
{
    public class AResponseBase<TData>
    {
        /// <summary>
        /// Данные результата запроса
        /// </summary>
        public required TData Data { get; set; }
    }
}