namespace Domain.Entities.Other
{
    public class Payment
    {
        public int Id { get; set; }
        public string PayedTransactionId { get; set; } = null!;
        public string? RefundTransactionId { get; set; }
        public string Nonce { get; set; } = null!;
        public decimal? PayedAmount { get; set; }
        public string CurrencyIsoCode { get; set; } = null!;
        public DateTime? TransactionDate { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
