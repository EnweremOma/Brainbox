using Brainbox.Domain.Data;
using Brainbox.Domain.Models;
using Brainbox.Domain.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainbox.Domain.Repository
{
    public class CartRepository: Repository<Cart>, ICartRepository
    {
        private BrainboxDBContext _db;
        
        public CartRepository(BrainboxDBContext db): base(db)
        {
            _db = db;
        }

        public string AddToCart(Cart cart)
        {
            int qty = 0;
            if (cart is null)
                return "55";

            var check = _db.Carts.Where(x => x.UserId == cart.UserId && x.ProductId == cart.ProductId).ToList();

            qty = check.Any() == true ? (check[0].Qty + cart.Qty) : cart.Qty;

            var checkProductQty = _db.Products.Where(x => x.Id == cart.ProductId && x.Quantity > qty).ToList();

            if (!checkProductQty.Any())
                return "88";

            cart.Qty = qty;
            if (check.Any())
            {
                (check[0].Qty) = qty;
            }
            else
            {
                _db.Carts.Add(cart);
            }

            if (_db.SaveChanges() > 0)
                return "00";

            return "99";
        }

        public IEnumerable<UserCart> GetAllCartByUserId(int userId)
        {
            var userCart = GetCarts();
            return userCart.Where(x => x.userId == userId).ToList();
        }

        public IEnumerable<UserCart> GetAllCarts()
        {
            return GetCarts();
        }

        private IEnumerable<UserCart> GetCarts()
        {
            var userCart = from c in _db.Carts.AsEnumerable()
                           join p in _db.Products.AsEnumerable() on c.ProductId equals p.Id
                           join u in _db.Users.AsEnumerable() on c.UserId equals u.UserId
                           select new UserCart
                           {
                               id = c.Id,
                               productId = c.ProductId,
                               userId = c.UserId,
                               productName = p.Name,
                               userEmail = u.Email,
                               quantity = c.Qty,
                               unitPrice = p.Price,
                           };
            return userCart.ToList();
        }

        public int Save()
        {
           return _db.SaveChanges();
        }

        public void Update(Cart obj)
        {
            _db.Carts.Update(obj);
        }

        public UserCartTotal CartTotal(int userId)
        {
            decimal total = 0;
            UserCartTotal userCartTotal = new UserCartTotal();

            var userCart = GetCarts();
            var items = userCart.Where(x => x.userId == userId);
            foreach (var item in items)
            {
                total += (item.quantity * item.unitPrice);
            }
            userCartTotal.cart = items.ToList();
            userCartTotal.total = total;

            return userCartTotal;
        }
    }
}
