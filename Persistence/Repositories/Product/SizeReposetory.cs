using Domain.Entities;
using Domain.Repositorie;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class SizeReposetory : ISizeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SizeReposetory(ApplicationDbContext dbContext) =>
       _dbContext = dbContext;


    public void Add(Size entity) =>
        _dbContext.Sizes.Add(entity);

    public void Delete(Size entity) =>
        _dbContext.Sizes.Remove(entity);

    public Size? Get(int id) =>
        GetAll().Find(s => s.Id == id);

    public List<Size> Get(string name) =>
           GetAll().FindAll(s => s.Name == name);

    public List<Size> GetAll() =>
        _dbContext.Sizes
        .Include(s => s.Varients)
        .ToList();

    public void Update(Size entity) =>
        _dbContext.Sizes.Update(entity);
}
