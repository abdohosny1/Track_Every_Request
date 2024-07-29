using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Track_Every_Request.Model;
using Track_Every_Request.services;

namespace Track_Every_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataProcessController : ControllerBase
    {
        private readonly ILogger<DataProcessController> _logger;

        public DataProcessController(ILogger<DataProcessController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("simpleExtract")]
        public IActionResult simpleExtract()
        {
            Request.Headers.TryGetValue("x-correlation-Id", out var Id);
            _logger.LogInformation($"correlation = {Id}");
            return Ok("sucess");
        }

        [HttpGet]
        [Route("customAttributeExtract")]
        //[CustomHeader]
        [ReturnCustomHeader]
        public IActionResult customAttributeExtract()
        {
            HttpContext.Items.TryGetValue("x-correlation-Id", out var Id);
            _logger.LogInformation($"correlation = {Id}");

            //HttpContext.Response.Headers.Append("x-correlation-Id", Id.ToString());
            return Ok("sucess");
        }

        [HttpGet]
        [Route("simpleDtoExtract")]
        public IActionResult simpleDtoExtract([FromHeader] ReferenceDto referenceDto)
        {
            Request.Headers.TryGetValue("x-correlation-Id", out var Id);
            _logger.LogInformation($"correlation Id = {referenceDto.CorrelationID}");
            _logger.LogInformation($"Trace Id = {referenceDto.TraceId}");
            return Ok("sucess");
        }
    }
}
