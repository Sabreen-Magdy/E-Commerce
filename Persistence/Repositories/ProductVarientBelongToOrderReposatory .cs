﻿using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductVarientBelongToOrderReposatory : IProductVarientBelongToOrderReposatory
    {
        private readonly ApplicationDbContext _context;
        public ProductVarientBelongToOrderReposatory(
            ApplicationDbContext context) => _context = context;
 

        public void Add(ProductVarientBelongToOrder entity)
        {
           _context.ProductVarientBelongToOrder.Add(entity);
        }

        public void Delete(ProductVarientBelongToOrder entity)
        {
            _context.ProductVarientBelongToOrder.Remove(entity);
        }

        public ProductVarientBelongToOrder? Get(int id)
        {
            return _context.ProductVarientBelongToOrder.FirstOrDefault(o => o.Id == id);
        }

        public List<ProductVarientBelongToOrder> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<ProductVarientBelongToOrder> GetAll()
        {
            return _context.ProductVarientBelongToOrder
                .Include(pvo => pvo.ProductVarient)
                    .ThenInclude(pv => pv.ColoredProduct)
                    .ThenInclude(cp => cp.Product)
                .Include(pvo => pvo.Order)
                .ToList();
        }

        public void Update(ProductVarientBelongToOrder entity)
        {
            _context.ProductVarientBelongToOrder.Update(entity);
        }
    }
}