using MobileBankingWebApi.Models.ModelRequests;
using MobileBankingWebApi.Models.ModelResponses;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using MobileBankingWebApi.Models;
using System.Text.Json;

namespace MobileBankingWebApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly StaticData _staticData;

        public TransactionService(StaticData staticData)
        {
            _staticData = staticData;
        }
        public async Task<Dictionary<string, object>?> CreatePayment(PaymentModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "AGENT_API_Pay";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@paymentID", modelRequest.PaymentId);
            command.Parameters.AddWithValue("@login", modelRequest.Login);
            command.Parameters.AddWithValue("@hash", modelRequest.Hash);
            command.Parameters.AddWithValue("@number", modelRequest.Number);
            command.Parameters.AddWithValue("@numberAdditional", modelRequest.NumberAdditional);
            command.Parameters.AddWithValue("@ExternalID", modelRequest.ExternalId);
            command.Parameters.AddWithValue("@Summa", modelRequest.Summa);
            command.Parameters.AddWithValue("@timestamp", modelRequest.TimeStamp);

            try
            {
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                Dictionary<string, object>? items = null;
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        try
                        {
                            items = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
                await reader.CloseAsync();
                await connection.CloseAsync();

                return items;
            }
            catch (Exception)
            {
                if (connection.State != ConnectionState.Closed)
                {
                    await connection.CloseAsync();
                }

                return null;
            }
        }

        public async Task<Dictionary<string, object>?> GetPayments(GetPaymentListModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "AGENT_API_List";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@login", modelRequest.Login);
            command.Parameters.AddWithValue("@hash", modelRequest.Hash);
            command.Parameters.AddWithValue("@timestamp", modelRequest.TimeStamp);
            command.Parameters.AddWithValue("@type", modelRequest.Type);
            try
            {
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                var modelResponse = new Dictionary<string, object>();
                var dataList = new List<Dictionary<string, object>>();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        modelResponse["Code"] = reader.GetInt32("Code");
                        modelResponse["Message"] = reader.GetString("Message");

                        try
                        {
                            var result = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);

                            result.Remove("Code");

                            result.Remove("Message");

                            dataList.Add(result); 
                        }
                         catch (IndexOutOfRangeException) 
                        {

                        }

                    }
                }
                modelResponse["Data"] = dataList;

                await reader.CloseAsync();
                await connection.CloseAsync();

                return modelResponse;
            }
            catch(Exception)
            {
                if(connection.State != ConnectionState.Closed)
                {
                    await connection.CloseAsync();
                }

                return null;
            }
        }

        public async Task<Dictionary<string, object>?> GetTransactionInfo(TransactionInfoModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "AGENT_API_Info";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@login", modelRequest.Login);
            command.Parameters.AddWithValue("@hash", modelRequest.Hash);
            command.Parameters.AddWithValue("@timestamp", modelRequest.TimeStamp);
            command.Parameters.AddWithValue("@paymentID", modelRequest.PaymentId);
            command.Parameters.AddWithValue("@number", modelRequest.Number);
            command.Parameters.AddWithValue("@numberAdditional", modelRequest.NumberAdditional);

            try
            {
                await connection.OpenAsync();
                using var reader = command.ExecuteReader();
                Dictionary<string, object> modelResponse = new();
                List<Dictionary<string, object>> dataList = new();
                if (reader.HasRows)
                {
                    while(await reader.ReadAsync())
                    {
                        
                        modelResponse["Code"] = reader.GetInt32("Code");
                        modelResponse["Message"] = reader.GetString("Message");

                        var result = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);

                        result.Remove("Code");
                        result.Remove("Message");

                        dataList.Add(result);

                    }
                    modelResponse["Data"] = dataList;
                }
                await reader.CloseAsync();
                await connection.CloseAsync();

                return modelResponse;
            }
            catch(Exception) 
            {
                if (connection.State != ConnectionState.Closed)
                {
                    await connection.CloseAsync();
                }

                return null;
            }
        }

        public async Task<Dictionary<string, object>?> GetTransactionStatus(TransactionStatusModelRequest modelRequest)
        {
            using var connection = new SqlConnection(_staticData.ConnectionString);

            var query = "AGENT_API_Status";

            using var command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@transactionID", modelRequest.TransactionId);
            command.Parameters.AddWithValue("@login", modelRequest.Login);
            command.Parameters.AddWithValue("@hash", modelRequest.Hash);
            command.Parameters.AddWithValue("@timestamp", modelRequest.TimeStamp);

            try
            {
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                Dictionary<string, object>? items = null;
                if (reader.HasRows)
                {
                    items = new();
                    while (await reader.ReadAsync())
                    {
                        items = Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
                    }
                }
                await reader.CloseAsync();
                await connection.CloseAsync();

                return items;
            }
            catch (Exception)
            {
                if (connection.State != ConnectionState.Closed)
                {
                    await connection.CloseAsync();
                }

                return null;
            }
        }
    }
}