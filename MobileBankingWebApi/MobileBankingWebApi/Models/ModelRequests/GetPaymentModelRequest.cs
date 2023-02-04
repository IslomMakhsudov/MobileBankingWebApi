namespace MobileBankingWebApi.Models.ModelRequests
{
    public class GetPaymentListModelRequest
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public string TimeStamp { get; set; }
        public int Type { get; set; }
    }
}
