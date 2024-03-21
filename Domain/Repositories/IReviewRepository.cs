using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        Review? Get(int id);
        void Add(Review review);
        void Update(Review review);
        void Delete(int id);

    }
}
