using Microsoft.EntityFrameworkCore;
using PerfectChannel.WebApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Models
{
	public class TodoService : ITodoService
	{
		private readonly TasksContext _context;

		public TodoService(TasksContext context)
		{
			_context = context;
		}

		public async Task<
			IEnumerable<TodoViewModel>> Read()
		{
			IEnumerable<TodoViewModel> result;

			using (_context)
			{
				var modelResult = await _context.Todos.ToListAsync();

				result = modelResult.Select(t => new TodoViewModel() { ID = t.ID, Description = t.Description, Completed = t.Completed });
			}

			return result;
		}
	}
}
