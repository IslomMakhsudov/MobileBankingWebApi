using System.Reflection.Metadata.Ecma335;
using MobileBankingWebApi.Models;

namespace MobileBankingWebApi.Modules.Payment.ModelResponses
{
    public class PaymentModelResponse : BaseEntity
    {
        public int TransactionId { get; set; }
        public DateOnly? ServerAcceptedDate { get; set; }
    }
}
