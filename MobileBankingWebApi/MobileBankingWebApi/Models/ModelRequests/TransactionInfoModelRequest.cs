namespace MobileBankingWebApi.Models.ModelRequests
{
    public class TransactionInfoModelRequest
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public string TimeStamp { get; set; }
        public string PaymentId { get; set; }
        public string Number { get; set; }
        public string? NumberAdditional { get; set; }
    }
}
