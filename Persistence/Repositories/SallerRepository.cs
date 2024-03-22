using Domain.Entities;
using Domain.Repositories;
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

        public List<Domain.Entities.Saller> GetAll()
        {
            return _context.Saller.ToList();
        }

        public Saller Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Saller saller)
        {
            throw new NotImplementedException();
        }

        public void Update(Saller saller)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
