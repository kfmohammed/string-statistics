using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using TechTest;

namespace TestTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringStatsController : ControllerBase
    {
        private readonly ILogger<StringStatsController> _logger;
        private readonly IStringStatsProcessor _stringStatsProcessor;

        public StringStatsController(ILogger<StringStatsController> logger, IStringStatsProcessor stringStatsProcessor)
        {
            _logger = logger;
            _stringStatsProcessor = stringStatsProcessor;
        }

        [HttpPost]
        public ObjectResult Post(CancellationToken cancellationToken, [FromBody] string subject)
        {
            try
            {
                return Ok(_stringStatsProcessor.Run(subject));
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return BadRequest(e.Message);
            }
        }
    }
}
