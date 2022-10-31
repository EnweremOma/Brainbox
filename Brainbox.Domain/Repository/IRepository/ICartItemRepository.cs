using Brainbox.Domain.Models;


namespace Brainbox.Domain.Repository.IRepository
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        void Update(CartItem obj);
        void Save();
    }
}
