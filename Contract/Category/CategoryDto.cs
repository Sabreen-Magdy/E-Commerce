
namespace Contract;

public record  CategoryDto(int Id, string Name,
    string? Icon, string? Description)
{
}

public record ProductCategoriesDto(int Id, string Name)
{
}
