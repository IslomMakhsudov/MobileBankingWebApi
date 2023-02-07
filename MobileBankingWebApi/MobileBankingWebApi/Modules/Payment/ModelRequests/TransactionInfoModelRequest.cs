namespace MobileBankingWebApi.Modules.Payment.ModelRequests
{
    public class TransactionInfoModelRequest
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public int TimeStamp { get; set; }
        public string PaymentId { get; set; }
        public string Number { get; set; }
        public string? NumberAdditional { get; set; }
    }
}
