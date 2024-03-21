using Domain.Entities;

namespace Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    List<TEntity> GetAll();
    TEntity? Get(int id);
    List<TEntity> Get(string name);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
