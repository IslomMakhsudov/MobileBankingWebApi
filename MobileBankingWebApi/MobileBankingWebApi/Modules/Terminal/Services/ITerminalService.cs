using MobileBankingWebApi.Modules.Terminal.ModelRequests;

namespace MobileBankingWebApi.Modules.Terminal.Services
{
    public interface ITerminalService
    {
        public Task<Dictionary<string, object>> CheckTerminalAuth(TerminalAuthModelRequest modelRequest);
    }
}
