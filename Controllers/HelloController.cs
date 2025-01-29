using FreeAutoApi.Facades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeAutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly HelloManager _helloManager;

        public HelloController(HelloManager helloManager)
        {
            _helloManager = helloManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            var messages = await _helloManager.GetHelloMessagesAsync();
            return Ok(messages);
        }
    }
}
