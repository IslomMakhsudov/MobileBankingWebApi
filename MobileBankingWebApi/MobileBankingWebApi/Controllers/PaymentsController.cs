using Microsoft.AspNetCore.Mvc;
using MobileBankingWebApi.Models;
using System.Text.Json.Nodes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using MobileBankingWebApi.Modules.Payment.Services;
using MobileBankingWebApi.Modules.Payment.ModelRequests;
using MobileBankingWebApi.Modules.Payment.ModelResponses;

namespace MobileBankingWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _transactionService;

        public PaymentsController(IPaymentService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(PaymentsListModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseEntity), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPayments([FromQuery] GetPaymentListModelRequest modelRequest)
        {
            var result = await _transactionService.GetPayments(modelRequest);

            if (result == null)
                return BadRequest();

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
        [ProducesResponseType(typeof(BaseEntity), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStatus([FromQuery] TransactionStatusModelRequest modelRequest)
        {
            var result = await _transactionService.GetPaymentStatus(modelRequest);

            if(result == null) 
                return BadRequest();

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
        [ProducesResponseType(typeof(BaseEntity), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentModelRequest modelRequest)
        {
            var result = await _transactionService.CreatePayment(modelRequest);

            if(result == null)
                return BadRequest();

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
        [ProducesResponseType(typeof(BaseEntity), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInfo([FromQuery] TransactionInfoModelRequest modelRequest)
        {
            var result = await _transactionService.GetPaymentInfo(modelRequest);

            if(result == null)
                return BadRequest();

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

        [HttpGet("balance")]
        [ProducesResponseType(typeof(PaymentBalanceModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseEntity), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPaymentBalance([FromQuery] PaymentBalanceModelRequest modelRequest)
        {
            var result = await _transactionService.GetPaymentBalance(modelRequest);

            if (result == null)
                return BadRequest();

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
