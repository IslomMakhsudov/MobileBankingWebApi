using System.Data.SqlTypes;

namespace MobileBankingWebApi.Models.ModelRequests
{
    public class PaymentModelRequest
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public int TimeStamp { get; set; }
        public string PaymentId { get; set; }
        public string Number { get; set; }
        public string? NumberAdditional { get; set; }
        public string ExternalId { get; set; }
        public decimal Summa { get; set; }
    }
}
