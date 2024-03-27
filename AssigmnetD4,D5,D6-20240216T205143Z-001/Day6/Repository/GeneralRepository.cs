
using AppAssigments.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAssigments.Repository
{
    public class GeneralRepository<T> : IGeneralInteface<T> where  T : class
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GeneralRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int Add(T entity)
        {
            try
            {
                applicationDbContext.Set<T>().Add(entity);
                return applicationDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public int Delete(T entity)
        {
            try
            {

                applicationDbContext.Set<T>().Remove(entity);
                return applicationDbContext.SaveChanges();

            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return applicationDbContext.Set<T>();
        }

        public T GetBySingelId(int id)
        {
            return applicationDbContext.Set<T>().Find(id);
        }

        public int Update(T entity)
        {
            try
            {

                applicationDbContext.Set<T>().Update(entity);
                return applicationDbContext.SaveChanges();

            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
