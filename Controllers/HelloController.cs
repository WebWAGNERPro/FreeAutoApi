using FreeAutoApi.Facades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace FreeAutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        // Route: /api/hello
        [HttpGet]
        public ActionResult<DataTable> Index()
        {
            DataTable messages = HelloManager.GetHelloMessages();
            return Ok(messages);
        }

        // Route: /api/hello/photos
        [HttpGet("photos")]
        public async Task<ActionResult<List<string>>> Photos()
        {
            var photos = await Task.FromResult(new List<string>
            {
                "photo1.jpg",
                "photo2.jpg",
                "photo3.jpg"
            });

            return Ok(photos);
        }
    }
}
