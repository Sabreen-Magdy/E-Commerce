using Contract;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;

namespace Services.DataServices
{
    internal class CategoryService : ICategoryService
    {
        private IAdminRepository _repositoryAdmin;

        private Category GetCategory(int id) {
          var category =  _repositoryAdmin.CategoryRepository
                .Get(id);
            if (category == null)
                throw new NotFoundException("Category");

            return category;
        }
        public CategoryService(IAdminRepository repositoryAdmin)
        {
            _repositoryAdmin = repositoryAdmin;
        }

        public void Add(CategoryNewDto category)
        {
            _repositoryAdmin.CategoryRepository
                .Add(category.ToCategoryEntity());
            _repositoryAdmin.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = GetCategory(id);
            _repositoryAdmin.CategoryRepository
                .Delete(category);

            _repositoryAdmin.SaveChanges();
        }

        public CategoryDto? Get(int id) => 
            GetCategory(id).ToCategoryDto();
        

        public CategoryDto? Get(string name) =>
            _repositoryAdmin.CategoryRepository
            .Get(name).FirstOrDefault()!.ToCategoryDto();

        public List<CategoryDto> GetAll() =>
            _repositoryAdmin.CategoryRepository
            .GetAll().ToCategoryDto();

        private Category UpdateCategory(Category category,
                           Dictionary<Properties, string> newValues)
        {
            foreach (var item in newValues)
            {
                switch (item.Key)
                {
                    case Properties.Name:
                        category.Name = item.Value;
                        break;
                    case Properties.Description:
                        category.Description = item.Value;
                        break;

                    default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
            return category;
        }
        public int NumProduct(int categoryId)
        {
           var category =  _repositoryAdmin.CategoryRepository.Get(categoryId);
            if (category == null)
                throw new NotFoundException("Category");
            return category.ProductCategories.Count;
        }
        public void Update(int id, Dictionary<Properties, string> newValues)
        {
            var category = GetCategory(id);
            UpdateCategory(category, newValues);
           
            _repositoryAdmin.SaveChanges();
        }
    }
}