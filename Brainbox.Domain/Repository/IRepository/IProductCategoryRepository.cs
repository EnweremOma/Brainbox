using Brainbox.Domain.Models;


namespace Brainbox.Domain.Repository.IRepository
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        void Update(ProductCategory obj);
        int Save();
    }
}
