using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Cart? Get(int id);
        void Add(Cart cart);
        void Update(Cart cart);
        void Delete(int id);

    }
}
