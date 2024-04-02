using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;
using System.Data;

namespace Persistence.Repositories
{
    public class SallerRepository : ISallerRepositry
    {
        private readonly ApplicationDbContext _context;

        public SallerRepository(ApplicationDbContext context) =>
            _context = context;
        public List<Saller> GetAll() =>
      _context.Sallers.ToList();
        public void Add(Saller saller)
        {
            _context.Sallers.Add(saller);
            _context.SaveChanges();
        }
        public void Delete(Saller saller)
        {
            _context.Sallers.Remove(saller);
            _context.SaveChanges();

        }
       
        public List<Saller> Get(string name) =>
    _context.Sallers.Where(c => c.Name == name)
                  .Select(c => c).ToList();
        public void Update(Saller saller)
        {
            _context.Sallers.Update(saller);
            _context.SaveChanges();

        }
                

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object GetByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Saller? Get(int id) =>
                _context.Sallers.Find(id);
         
    }
}
