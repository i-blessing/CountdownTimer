using CountdownTimer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace CountdownTimer.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class TimerController : ApiController
    {
        private readonly ITimerService _timerService;

        public TimerController(ITimerService timerService)
        {
            _timerService = timerService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = _timerService.GetTimers();
            return Ok(result);
        }
    }
}
