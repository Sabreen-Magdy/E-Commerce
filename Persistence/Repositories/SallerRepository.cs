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
        public List<Saller> GetAll() =>
      _context.Sallers.ToList();
        public void Add(Saller saller) =>
    _context.Sallers.Add(saller);

      //  public void Delete(Saller saller) =>
      //_context.Customers.Remove(saller.Id);
        public Domain.Entities.Customer? Get(int id) =>
          _context.Customers.Find(id);

        public List<Domain.Entities.Customer> Get(string name) =>
          _context.Customers.Where(c => c.Name == name)
                        .Select(c => c).ToList();

        public void Update(Domain.Entities.Customer customer) =>
          _context.Customers.Update(customer);


       


    }
}
