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

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _service.Read();

            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TodoViewModel model)
        {
            var result = await _service.Create(model.Description);

            return new JsonResult(result);
        }
    }
}