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
        public CartRepository(BrainboxDBContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Cart obj)
        {
            _db.Carts.Update(obj);
        }
    }
}
