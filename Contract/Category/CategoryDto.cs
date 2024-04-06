
namespace Contract;

public record  CategoryDto(int Id, string Name,
    string? Icon, string? Description, int NumberOfProducts)
{
}

public record ProductCategoriesDto(int Id, string Name)
{
}
