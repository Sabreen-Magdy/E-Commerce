namespace Contract;

public record ColorDto
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
}

public record SizeDto
{
    public int Id { get; set; }
    public string Size {  get; set; } = null!;
}
