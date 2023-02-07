using MobileBankingWebApi.Modules.Terminal.ModelRequests;
using MobileBankingWebApi.Services;
using System.Data.SqlClient;
using System.Data;

namespace MobileBankingWebApi.Modules.Terminal.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly StaticData _staticData;
        public TerminalService(StaticData staticData)
        {
            _staticData = staticData;
        }

        public async Task<Dictionary<string, object>> CheckTerminalAuth(TerminalAuthModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "AGENT_TERMINAL_Auth";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Password", modelRequest.Password);
            command.Parameters.AddWithValue("@Login", modelRequest.Login);

            try
            {
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    await reader.ReadAsync();

                    Dictionary<string, object> items = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);

                    return items;
                }
                await reader.CloseAsync();
                await connection.CloseAsync();

                throw new InvalidOperationException("Empty query result");
            }
            catch (Exception ex)
            {
                if (connection.State != ConnectionState.Closed)
                {
                    await connection.CloseAsync();
                }

                return CreateExceptionResult(ex.Message);
            }
        }

        private static Dictionary<string, object> CreateExceptionResult(string exceptionMessage)
        {
            Dictionary<string, object> errorResult = new()
            {
                ["exceptionMessage"] = exceptionMessage
            };

            return errorResult;
        }
    }
}
