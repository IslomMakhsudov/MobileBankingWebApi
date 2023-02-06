namespace MobileBankingWebApi.Models.ModelRequests
{
    public class PaymentBalanceModelRequest
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public string TimeStamp { get; set; }
    }
}
