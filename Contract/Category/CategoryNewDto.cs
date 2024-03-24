

namespace Contract;

public record CategoryNewDto
{
   public string Name { get; set; } = null!;
   public string Icon { get; set; } = null!;
   public string Description { get; set; } = null!;
}
