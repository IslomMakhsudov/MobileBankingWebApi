namespace MobileBankingWebApi.Models.ModelRequests
{
    public class GetPaymentListModelRequest
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public int TimeStamp { get; set; }
        public int Type { get; set; }
    }
}
