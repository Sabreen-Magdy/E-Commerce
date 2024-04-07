namespace Contract
{
    public record PaymentDto(decimal Amount, string Nonce, string CurrencyIsoCode)
    {
    }
}
