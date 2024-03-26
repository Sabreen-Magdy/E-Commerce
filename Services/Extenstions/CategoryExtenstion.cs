using Contract;
using Domain.Entities;
using System.Collections.Generic;

namespace Services.Extenstions
{
    public static class CategoryExtenstion
    {
        public static Category ToCategoryEntity(this CategoryNewDto category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            return new()
            {
                Name = category.Name,
                Description = category.Description,
                Icon = category.Icon,
            };
        }
        public static Category ToCategoryEntity(this CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            return new()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Icon = category.Icon,
            };
        }
        public static CategoryDto ToCategoryDto(this Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            return new(category.Id, category.Name,
                       category.Icon, category.Description);
        }
        public static List<CategoryDto> ToCategoryDto(this List<Category> categories)
        {
            if (categories == null)
                throw new ArgumentNullException(nameof(categories));

            List < CategoryDto > categoryDtos = new List<CategoryDto>();

            foreach (var item in categories)
                categoryDtos.Add(item.ToCategoryDto());

            return categoryDtos;
        }
    }
}
