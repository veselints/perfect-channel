using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Models
{
	public interface ITodoService
	{
		public Task<
			IEnumerable<TodoViewModel>> Read();
	}
}
