using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.WebApi.Data;
using PerfectChannel.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TasksContext _context;

        public TaskController(TasksContext context) 
        {
            _context = context;
        }

        public ActionResult Get()
        {
            List<Todo> result;

            using (_context)
            {
                result = _context.Todos.ToList();
            }

            return new JsonResult(result);
        }
        // TODO: to be completed
    }
}