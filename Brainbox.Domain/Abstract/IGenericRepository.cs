
using System.Linq.Expressions;


namespace Brainbox.Domain.Abstract
{
    public interface IGenericRepository<T>
    {
        T Get(int id);

        Task<T> GetAsync(int id);

        ICollection<T> GetAll();

        Task<ICollection<T>> GetAllAsync();

        T Find(Expression<Func<T, bool>> match);

        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        T Add(T t);

        Task<T> AddAsync(T t);

        IEnumerable<T> AddAll(IEnumerable<T> tList);

        Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList);

        T Update(T updated, int key);

        Task<T> UpdateAsync(T updated, int key);

        void Delete(T t);

        Task<int> DeleteAsync(T t);

        int Count();

        Task<int> CountAsync();
    }
}


