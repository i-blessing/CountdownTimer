using CountdownTimer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace CountdownTimer.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class InventoryController : ApiController
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = _inventoryService.GetInventory();

            return Ok(result);
        }
    }
}
