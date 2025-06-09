using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerBase.Interfaces;

namespace TaskManagerBase.Implementations
{
    /// <inheritdoc/>
    public class DefaultCripto : ICripto
    {
        public string Compute(string value) => value;

        public bool Verify(string value, string password) => value == password;
    }
}