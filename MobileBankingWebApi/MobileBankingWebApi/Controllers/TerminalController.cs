using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBankingWebApi.Models;
using MobileBankingWebApi.Modules.Payment.ModelResponses;
using MobileBankingWebApi.Modules.Terminal.ModelRequests;
using MobileBankingWebApi.Modules.Terminal.ModelResponses;
using MobileBankingWebApi.Modules.Terminal.Services;
using Newtonsoft.Json;

namespace MobileBankingWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalService _terminalService;

        public TerminalController(ITerminalService terminalService)
        {
            _terminalService = terminalService;
        }

        [HttpGet("auth")]
        [ProducesResponseType(typeof(TerminalAuthModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseEntity), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CheckTerminalAuth([FromQuery] TerminalAuthModelRequest modelRequest)
        {
            var result = await _terminalService.CheckTerminalAuth(modelRequest);

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
