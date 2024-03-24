using Contract;
using Domain.Enums;
using Domain.Repositories;
using Services.Abstraction.DataServices;

namespace Services.DataServices
{
    internal class CategoryService : ICategoryService
    {
        private IAdminRepository _repositoryAdmin;

        public CategoryService(IAdminRepository repositoryAdmin)
        {
            _repositoryAdmin = repositoryAdmin;
        }

        public void Add(CategoryNewDto customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto? Get(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Dictionary<Properties, string> newValues)
        {
            throw new NotImplementedException();
        }
    }
}