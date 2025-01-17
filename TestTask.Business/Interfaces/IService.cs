using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Business.Interfaces
{
    public interface IService<T> where T : class
    {
        Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Update(T entity);
        Task Remove(int id);
    }
}
