using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNT.DAL.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task Create(T model);
        Task Update(T model);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(); 
    }
}
