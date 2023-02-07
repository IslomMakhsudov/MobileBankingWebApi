namespace MobileBankingWebApi.Modules.Payment.ModelRequests
{
    public class PaymentBalanceModelRequest
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public string TimeStamp { get; set; }
    }
}
