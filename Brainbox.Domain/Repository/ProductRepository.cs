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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private BrainboxDBContext _db;
        public ProductRepository(BrainboxDBContext db) : base(db)
        {
            _db = db;
        }
        public int Save()
        {
            return _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }

    }
}
