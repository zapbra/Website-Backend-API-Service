using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.classes;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/logger")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        FileLogger fileLogger = new FileLogger();

        [HttpPost]
        public IActionResult Post([FromBody] LogModel log)
        {


            if (log == null || string.IsNullOrEmpty(log.PagePath) || string.IsNullOrEmpty(log.Message))
            {
                return BadRequest("Invalid log data");
            }

            bool logResult = fileLogger.WriteToFile($"Page: {log.PagePath}, Message: {log.Message}");

            if (logResult)
            {
                return Ok(new { Message = "Log successfully written" });
            }
            else
            {
                return StatusCode(500, "Failed to write log");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Successfully reached logger api" });

        }
    }
}
