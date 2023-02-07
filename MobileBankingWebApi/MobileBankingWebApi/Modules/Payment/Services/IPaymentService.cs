using MobileBankingWebApi.Modules.Payment.ModelRequests;

namespace MobileBankingWebApi.Modules.Payment.Services
{
    public interface IPaymentService
    {
        public Task<Dictionary<string, object>> GetPayments(GetPaymentListModelRequest modelRequest);
        public Task<Dictionary<string, object>> CreatePayment(PaymentModelRequest modelRequest);
        public Task<Dictionary<string, object>> GetPaymentInfo(TransactionInfoModelRequest modelRequest);
        public Task<Dictionary<string, object>> GetPaymentStatus(TransactionStatusModelRequest modelRequest);
        public Task<Dictionary<string, object>> GetPaymentBalance(PaymentBalanceModelRequest modelRequest);
    }
}
