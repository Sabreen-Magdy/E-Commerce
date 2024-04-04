using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Entities.Other
{
    public class Payment
    {
        public string CurrencyIsoCode { get; set; } = null!;
        public string ExpirationMonth { get; set; } = null!;
        public string ExpirationYear { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
        public DateTime? CreatedAt { get; set; } = null!;
        public string Bin { get; set; } = null!;
        public string LastFour { get; set; } = null!;
        public decimal? Amount { get; set; } 
        public string PaymentInstrumentSubtype { get; set; } = null!;
        public string Nonce {  get; set; } = null!;
    }
}
