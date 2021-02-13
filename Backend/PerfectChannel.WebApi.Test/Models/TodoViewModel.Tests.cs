using Moq;
using NUnit.Framework;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PerfectChannel.WebApi.Test.Models
{
	public class TodoViewModelTests
	{
		public TodoViewModelTests()
		{ 
		}

		[Test]
		public void ToEntity_Converts_To_Todo()
		{
			var todoViewModel = new TodoViewModel() { ID = 1, Completed = true, Description = "Task 1" };

			var result = todoViewModel.ToEntity();

			Assert.IsInstanceOf<Todo>(result);
			Assert.AreEqual(result.ID, todoViewModel.ID);
			Assert.AreEqual(result.Completed, todoViewModel.Completed);
			Assert.AreEqual(result.Description, todoViewModel.Description);
		}
	}
}
