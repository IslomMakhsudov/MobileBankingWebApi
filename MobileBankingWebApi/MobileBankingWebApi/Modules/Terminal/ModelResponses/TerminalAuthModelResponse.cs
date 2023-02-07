namespace MobileBankingWebApi.Modules.Terminal.ModelResponses
{
    public class TerminalAuthModelResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Login { get; set; }
        public int TerminalId { get; set; }
        public int TerminalKey { get; set; }
    }
}
