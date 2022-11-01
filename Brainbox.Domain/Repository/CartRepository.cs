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
        private IRepository<Product> _productRepository;
        public CartRepository(BrainboxDBContext db, IRepository<Product> productRepository) : base(db)
        {
            _db = db;
            _productRepository = productRepository;
        }

        public string AddToCart(Cart cart)
        {
            int qty = 0;
            if (cart is null)
                return "55";

            var check = _db.Carts.Where(x => x.UserId == cart.UserId && x.ProductId == cart.ProductId).ToList();

            qty = check.Any() == true ? (check[0].Qty + cart.Qty) : cart.Qty;

            var checkProductQty = _productRepository.GetFirstOrDefault(x => x.Id == cart.ProductId && x.Quantity > qty);

            if (checkProductQty == null)
                return "88";

            cart.Qty = qty;
            _db.Carts.Add(cart);

            if (_db.SaveChanges() > 0)
                return "00";

            return "99";
        }

        public int Save()
        {
           return _db.SaveChanges();
        }

        public void Update(Cart obj)
        {
            _db.Carts.Update(obj);
        }

    }
}
