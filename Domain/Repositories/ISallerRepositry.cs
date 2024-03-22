using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
  public interface ISallerRepositry
    {
        Saller? Get(int id);
        void Add(Saller saller);
        void Update(Saller saller );
        void Delete(int id);
    }
}
