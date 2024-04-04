using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public record PaymentDto(decimal Amount, string Nonce, string CurrencyIsoCode)
    {
    }
}
