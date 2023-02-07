using MobileBankingWebApi.Models;

namespace MobileBankingWebApi.Modules.Payment.ModelResponses
{
    public class PaymentsListModelResponse : BaseEntity
    {
        public List<Dictionary<string, object>> Data { get; set; } = new();
    }
}
