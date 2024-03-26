using Contract;
using Domain.Enums;

namespace Services.Abstraction.DataServices
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();

        CategoryDto? Get(int id);
        CategoryDto? Get(string name);

        void Add(CategoryNewDto category);

        void Update(CategoryDto categoryDto);

        void Delete(int id);
    }
}
