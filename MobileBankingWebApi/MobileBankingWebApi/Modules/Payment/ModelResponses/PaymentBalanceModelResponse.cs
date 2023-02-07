namespace MobileBankingWebApi.Modules.Payment.ModelResponses
{
    public class PaymentBalanceModelResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public decimal Balance { get; set; }
        public string UserName { get; set; }
        public decimal DollarRate { get; set; }
    }
}
