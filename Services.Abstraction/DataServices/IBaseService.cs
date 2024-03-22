using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.DataServices
{
    public interface IBaseService<Tdto> where Tdto : class
    {
        public List<Tdto> GetAll();
        public Tdto Get(int id);
        public Tdto Get(string Name);
        public void Add(Tdto DTO);
        public void Update(Tdto DTO);
        public void Delete(int id);
    }
}
