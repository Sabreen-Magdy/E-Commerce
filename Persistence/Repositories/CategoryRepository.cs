﻿using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) =>
           _dbContext = dbContext;


        public void Add(Category entity) =>
            _dbContext.Categories.Add(entity);

        public void Delete(Category entity) =>
            _dbContext.Categories.Remove(entity);

        public Category? Get(int id) =>
            GetAll().Find(s => s.Id == id);

        public List<Category> Get(string name) =>
               GetAll().FindAll(s => s.Name == name);

        public List<Category> GetAll() =>
            _dbContext.Categories
           .Include(c => c.ProductCategories)
            .ThenInclude(cp => cp.Product)
             .ThenInclude(p => p.ColoredProducts)
               .ThenInclude(pc => pc.Varients)
            .ToList();

        public int NumProduct(int categoryId) =>
            _dbContext.Categories
            .SelectMany(c => c.ProductCategories,  (c, pc) => pc)
            .Count(pc => pc.CategoryId ==  categoryId);
          
        public void Update(Category entity) =>
            _dbContext.Categories.Update(entity);
       
    }
}
