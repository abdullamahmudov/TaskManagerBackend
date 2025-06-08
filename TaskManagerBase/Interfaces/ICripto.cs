using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Interfaces
{
    public interface ICripto
    {
        string Compute(string value);
        bool Verify(string value, string password);
    }
}