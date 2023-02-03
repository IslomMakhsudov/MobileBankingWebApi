namespace MobileBankingWebApi.Models.ModelResponses
{
    public class PaymentsListModelResponse : BaseModel
    {
        public List<Dictionary<string, object>> Data { get; set; } = new();
    }
}
