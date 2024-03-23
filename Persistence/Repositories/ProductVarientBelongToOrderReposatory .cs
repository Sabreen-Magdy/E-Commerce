using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductVarientBelongToOrderReposatory : IProductVarientBelongToOrderReposatory
    {
        private readonly ApplicationDbContext _context;
        public ProductVarientBelongToOrderReposatory(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProductVarientBelongToOrder entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductVarientBelongToOrder entity)
        {
            throw new NotImplementedException();
        }

        public ProductVarientBelongToOrder? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductVarientBelongToOrder> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<ProductVarientBelongToOrder> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductVarientBelongToOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
