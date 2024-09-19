using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleSample.Interfaces;
using ScheduleSample.Dtos;

namespace ScheduleSample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public HomeController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("load-data")]
        public async Task<IActionResult> LoadData([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var response = await _scheduleService.GetScheduleEventsAsync(startDate, endDate);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }

        [HttpPost("update-data")]
        public async Task<IActionResult> UpdateData([FromBody] ScheduleEventRequestDto param)
        {
            var response = await _scheduleService.UpdateScheduleEventAsync(param);

            if (response.CodigoHttp == HttpStatusCode.OK)
            {
                return Ok(response.DadosRetorno);
            }
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}