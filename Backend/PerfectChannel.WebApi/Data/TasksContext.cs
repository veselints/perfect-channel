using Microsoft.EntityFrameworkCore;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Data
{
	public class TasksContext : DbContext
	{
		public TasksContext(DbContextOptions<TasksContext> options) : base(options)
		{ }

		public DbSet<Todo> Todos { get; set;  }
	}
}
