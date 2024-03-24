using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFavouriteRepository : IBaseRepository<Favourite>
    {
        List<Favourite> GetByCustomer(int customerID); 
        List<Favourite> GetByProduct(int productID);
    }
}
