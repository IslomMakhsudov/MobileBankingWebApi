using System.Reflection.Metadata.Ecma335;

namespace MobileBankingWebApi.Models.ModelRequests
{
    public class TransactionStatusModelRequest
    {
        public int TransactionId { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public int TimeStamp { get; set; }
    }
}
