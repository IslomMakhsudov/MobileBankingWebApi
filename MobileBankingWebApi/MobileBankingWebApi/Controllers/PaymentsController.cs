using Microsoft.AspNetCore.Mvc;
using MobileBankingWebApi.Models;
using MobileBankingWebApi.Models.ModelRequests;
using MobileBankingWebApi.Models.ModelResponses;
using MobileBankingWebApi.Services;
using System.Text.Json.Nodes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft;
using Newtonsoft.Json;

namespace MobileBankingWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : Controller
    {
        private readonly ITransactionService _transactionService;

        public PaymentsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(PaymentsListModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPayments([FromQuery] GetPaymentListModelRequest modelRequest)
        {
            var result = await _transactionService.GetPayments(modelRequest);

            if (result.ContainsKey("exception"))
                return BadRequest(result);
            

            if (HttpContext.Request.Headers["Accept"].ToString().ToLower() == "application/xml")
            {

                var json = JsonConvert.SerializeObject(result);
                var xml = JsonConvert.DeserializeXmlNode(json,"settings");

                return Ok(xml);
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpGet("status")]
        [ProducesResponseType(typeof(TransactionStatusModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStatus([FromQuery] TransactionStatusModelRequest modelRequest)
        {
            var result = await _transactionService.GetTransactionStatus(modelRequest);

            if (result.ContainsKey("exception"))
                return BadRequest(result);

            if (HttpContext.Request.Headers["Accept"].ToString().ToLower() == "application/xml")
            {

                var json = JsonConvert.SerializeObject(result);
                var xml = JsonConvert.DeserializeXmlNode(json, "settings");

                return Ok(xml);
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpPost("pay")]
        [ProducesResponseType(typeof(PaymentModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentModelRequest modelRequest)
        {

            var result = await _transactionService.CreatePayment(modelRequest);

            if (result.ContainsKey("exception"))
                return BadRequest(result);

            if (HttpContext.Request.Headers["Accept"].ToString().ToLower() == "application/xml")
            {

                var json = JsonConvert.SerializeObject(result);
                var xml = JsonConvert.DeserializeXmlNode(json, "settings");

                return Ok(xml);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("info")]
        [ProducesResponseType(typeof(TransactionInfoListModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInfo([FromQuery] TransactionInfoModelRequest modelRequest)
        {
            var result = await _transactionService.GetTransactionInfo(modelRequest);

            if (result.ContainsKey("exception"))
                return BadRequest(result);

            if (HttpContext.Request.Headers["Accept"].ToString().ToLower() == "application/xml")
            {

                var json = JsonConvert.SerializeObject(result);
                var xml = JsonConvert.DeserializeXmlNode(json, "settings");

                return Ok(xml);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
