using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Models.Shared
{
    public class RegistractionUser
    {
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
    }
}