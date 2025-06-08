using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Requests
{
    public abstract class AAuthKeyRequestBase<TData>
    {
        public required string AuthKey { get; set; }
        public required TData Data { get; set; }
    }
}