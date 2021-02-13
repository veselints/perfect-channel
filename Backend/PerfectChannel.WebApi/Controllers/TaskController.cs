using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.WebApi.Models;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITodoService _service;

        public TaskController(ITodoService service) 
        {
            _service = service;
        }

        public async Task<ActionResult> Get()
        {
            var result = await _service.Read();

            return new JsonResult(result);
        }
    }
}