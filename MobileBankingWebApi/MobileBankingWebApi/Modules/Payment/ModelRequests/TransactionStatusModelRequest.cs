using System.Reflection.Metadata.Ecma335;

namespace MobileBankingWebApi.Modules.Payment.ModelRequests
{
    public class TransactionStatusModelRequest
    {
        public int TransactionId { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public int TimeStamp { get; set; }
    }
}
