namespace Contract
{
    public record UserDto
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
    }

    public record LoginDto(string Email, string Password)
    {
    }
}
