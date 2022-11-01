using Brainbox.Domain.Models;


namespace Brainbox.Domain.Repository.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        string AddToCart(Cart cart);
        void Update(Cart obj);
        int Save();
    }
}
