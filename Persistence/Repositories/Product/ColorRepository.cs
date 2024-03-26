using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    internal class ColorRepository : IColorRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public ColorRepository(ApplicationDbContext dbContext) =>
           _dbContext = dbContext;


        public void Add(Color entity) =>
            _dbContext.Colors.Add(entity);

        public void Delete(Color entity) =>
            _dbContext.Colors.Remove(entity);

        public Color? Get(int id)
        {
            return _dbContext.Colors.Include(c=>c.ColoredProducts).FirstOrDefault(c => c.Id == id);
        }

        public List<Color> Get(string name) =>
               GetAll().FindAll(s => s.Name == name);

        public List<Color> GetAll() =>
            _dbContext.Colors
            .Include(c => c.ColoredProducts)
            .ToList();

        public void Color(Color entity) =>
            _dbContext.Colors.Update(entity);

        public void Update(Color entity)
        {
            _dbContext.Colors.Update(entity);
        }
            
    }
}
