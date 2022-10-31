using Brainbox.Domain.Models;

namespace Brainbox.Domain.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        int Save();
    }
}
