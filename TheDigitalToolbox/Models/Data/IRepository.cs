using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheDigitalToolbox.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> options);
        Task<IEnumerable<T>> ListAsync(QueryOptions<T> options);

        T Get(int id);
        T Get(string id);
        ValueTask<T> GetAsync(int id);
        ValueTask<T> GetAsync(string id);
        T Get(QueryOptions<T> options);

        void Insert(T entity);
        void InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        void SaveAsync();
    }
}
