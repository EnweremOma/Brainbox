using Brainbox.Domain.Models;


namespace Brainbox.Domain.Repository.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        IEnumerable<UserCart> GetAllCarts();
        IEnumerable<UserCart> GetAllCartByUserId(int userId);
        string AddToCart(Cart cart);
        void Update(Cart obj);
        int Save();
        UserCartTotal CartTotal(int userId);
    }
}
