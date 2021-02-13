using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Models
{
	public interface ITodoService
	{
		public Task<IEnumerable<TodoViewModel>> Read();

		public Task<TodoViewModel> Create(string description);

		public void Update(Todo model);
	}
}
