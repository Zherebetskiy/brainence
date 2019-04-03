using Brainence.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brainence.Domain.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task CreateAsync(T entity);
        Task Delete(int id);
        Task Delete();
        Task Update(T entity);
    }
}
