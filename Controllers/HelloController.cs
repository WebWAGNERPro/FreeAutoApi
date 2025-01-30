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
            try
            {
                DataTable messages = HelloManager.GetHelloMessages();
                if (messages.Rows.Count == 0)
                {
                    return NoContent();
                }
                return Ok(messages);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "Une erreur est survenue", details = ex.Message });
            }
        }

        // Route: /api/hello/photos
        [HttpGet("photos")]
        public async Task<ActionResult<List<string>>> Photos()
        {
            try
            {
                var photos = await Task.FromResult(new List<string>
                {
                    "photo1.jpg",
                    "photo2.jpg",
                    "photo3.jpg"
                });

                return Ok(photos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "Une erreur est survenue", details = ex.Message });
            }
        }
    }
}
