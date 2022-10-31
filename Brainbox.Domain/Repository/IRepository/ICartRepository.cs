using Brainbox.Domain.Models;


namespace Brainbox.Domain.Repository.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        void Update(Cart obj);
        void Save();
    }
}
