using System.Collections;

namespace AppAssigments.Repository
{
    public interface IGeneralInteface<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public int Add(T entity);
        public int Delete(T entity);
        public int Update(T entity);
        public T GetBySingelId(int id);
    }
}
