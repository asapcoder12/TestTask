using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services
{
    public interface ICsvParser
    {
        Task<List<T>> ParseCsvAsync<T>(Stream fileStream) where T : class;
    }
}
