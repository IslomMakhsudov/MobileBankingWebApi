namespace MobileBankingWebApi.Models.ModelResponses
{
    public class TransactionStatusModelResponse : BaseModel
    {
        public int TransactionId { get; set; }
        public string? TransactionStatus { get; set; }
    }
}
