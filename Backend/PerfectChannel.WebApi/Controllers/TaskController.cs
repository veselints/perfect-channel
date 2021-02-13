using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public ActionResult Get()
        {
            return new JsonResult(new { test = "hop" });
        }
        // TODO: to be completed
    }
}