using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Saller;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SallerRepository : ISallerRepositry
    {
        private readonly ApplicationDbContext _context;

        public SallerRepository(ApplicationDbContext context) =>
            _context = context;
        public List<Saller> GetAll() =>
      _context.Sallers.ToList();
        public void Add(Saller saller) =>
    _context.Sallers.Add(saller);

        public void Get(int id) =>
          _context.Sallers.Find(id);

        public void Delete(Saller saller) =>
      _context.Sallers.Remove(saller);

        public List<Saller> Get(string name) =>
    _context.Sallers.Where(c => c.Name == name)
                  .Select(c => c).ToList();
        public void Update(Saller saller) =>
   _context.Sallers.Update(saller);

        Saller? IBaseRepository<Saller>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
