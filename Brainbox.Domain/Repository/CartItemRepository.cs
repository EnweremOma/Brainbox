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
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        private BrainboxDBContext _db;

        public CartItemRepository(BrainboxDBContext db) : base(db)
        {
          _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CartItem obj)
        {
            _db.CartItems.Update(obj);
        }
    }
}
