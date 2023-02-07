using MobileBankingWebApi.Models;

namespace MobileBankingWebApi.Modules.Payment.ModelResponses
{
    public class TransactionStatusModelResponse : BaseEntity
    {
        public int TransactionId { get; set; }
        public string? TransactionStatus { get; set; }
    }
}
