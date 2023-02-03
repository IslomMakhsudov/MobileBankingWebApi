namespace MobileBankingWebApi.Models.ModelResponses
{
    public class TransactionInfoListModelResponse : BaseModel
    {
        public List<Dictionary<string, object>> Data { get; set; } = new();
    }
}
