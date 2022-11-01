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
   public class ProductCategoryRepository: Repository<ProductCategory>, IProductCategoryRepository
   {
        private BrainboxDBContext _db;
		public ProductCategoryRepository(BrainboxDBContext db) : base(db)
		{
			_db = db;
		}
        public int Save()
        {
           return _db.SaveChanges();
        }

        public void Update(ProductCategory obj)
        {
            _db.ProductCategories.Update(obj);
        }
   }
}
