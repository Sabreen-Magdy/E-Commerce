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

        public CategoryService(IAdminRepository repositoryAdmin)
        {
            _repositoryAdmin = repositoryAdmin;
        }

        private Category GetCategory(int id)
        {
            var category = _repositoryAdmin.CategoryRepository
                  .Get(id);
            if (category == null)
                throw new NotFoundException("Category");

            return category;
        }

        private bool CanRemove(Category category)
        {
            var productCategory = category.ProductCategories.Select(pc => pc.Product);
            if (productCategory.Count() == 0) return true;

           var varients = productCategory
                .SelectMany(pc => pc.ColoredProducts, (pc, cp) => cp.Varients);
            if (varients.Count() == 0) return true;

            return varients.SelectMany(v => v, (v, varient) => varient.Quantity).Sum() == 0;
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
            if (category == null)
                throw new NotFoundException("Category");

            if (CanRemove(category))
            {
                _repositoryAdmin.CategoryRepository
                    .Delete(category);

                _repositoryAdmin.SaveChanges();
            }
            throw new NotAllowedException("This Category has one or more Products in Store");
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
                    case Properties.Icon:
                        category.Icon = item.Value;
                        break;

                    default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
            return category;
        }
        public int NumProduct(int categoryId)
        {
            return _repositoryAdmin.CategoryRepository.NumProduct(categoryId);
        }
        public void Update(int id, Dictionary<Properties, string> newValues)
        {
            var category = GetCategory(id);
            UpdateCategory(category, newValues);
           
            _repositoryAdmin.SaveChanges();
        }
    }
}