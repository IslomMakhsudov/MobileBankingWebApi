using MobileBankingWebApi.Models.ModelRequests;
using MobileBankingWebApi.Models.ModelResponses;

namespace MobileBankingWebApi.Services
{
    public interface ITransactionService
    {
        public Task<Dictionary<string, object>> GetPayments(GetPaymentListModelRequest modelRequest);
        public Task<Dictionary<string, object>> CreatePayment(PaymentModelRequest modelRequest);
        public Task<Dictionary<string, object>> GetTransactionInfo(TransactionInfoModelRequest modelReqeust);
        public Task<Dictionary<string, object>> GetTransactionStatus(TransactionStatusModelRequest modelRequest);
    }
}
