using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerBase.Interfaces
{
    /// <summary>
    /// Зашифровка строковых значений
    /// </summary>
    public interface ICripto
    {
        /// <summary>
        /// Зашифровать строку
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Зашифрованная строка</returns>
        string Compute(string value);
        /// <summary>
        /// Проверить соответсвие строки с зашифрованной строкой
        /// </summary>
        /// <param name="value">Проверяемая строка</param>
        /// <param name="password">Зашифрованная строка</param>
        /// <returns></returns>
        bool Verify(string value, string password);
    }
}