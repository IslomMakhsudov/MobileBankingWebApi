using System.Reflection.Metadata.Ecma335;

namespace MobileBankingWebApi.Models.ModelResponses
{
    public class PaymentModelResponse : BaseModel
    {
        public int TransactionId { get; set; }
        public DateOnly? ServerAcceptedDate { get; set; }
    }
}
