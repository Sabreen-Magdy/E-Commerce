namespace Contract
{
    public record UserDto
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
    }
}
