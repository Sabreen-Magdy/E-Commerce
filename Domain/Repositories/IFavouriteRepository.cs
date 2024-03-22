using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFavouriteRepository
    {
        Favourite? GetById(int id);
        Favourite? GetByCustomerId(int id);
        void Add(Favourite favourite);
        void Update(Favourite favourite);
        void Delete(int id);

    }
}
