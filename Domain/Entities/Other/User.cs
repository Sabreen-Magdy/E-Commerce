namespace Domain.Entities.Other
{
    public record User
    {
        public int Id { get; set; }
        public List<string> Role { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime ExpiredDate { get; set; }
    }

    public record LoginDto(string Email, string Password)
    {
    }

    public record ChangePasswordDto(int Id, string OldPassword, string NewPassword)
    {
    }
    public record ForgetPasswordDto(string Token, string OTP, int Id, string NewPassword)
    {
    }

    public record OtpToken(string Token, string Otp) { }
}
