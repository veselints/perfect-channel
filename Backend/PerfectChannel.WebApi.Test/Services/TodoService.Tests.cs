using Moq;
using NUnit.Framework;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PerfectChannel.WebApi.Test.Services
{
    public class TodoServiceTests
    {
        public TodoServiceTests()
        {
        }

        [Test]
        public async Task Read_Returns_Result()
        {
            var options = new DbContextOptionsBuilder<TasksContext>()
                .UseInMemoryDatabase(databaseName: "MockDb")
                .Options;

            using (var context = new TasksContext(options))
            {
                context.Todos.Add(new Todo() { ID = 1, Description = "First", Completed = true });
                context.Todos.Add(new Todo() { ID = 2, Description = "Second", Completed = true });
                context.Todos.Add(new Todo() { ID = 3, Description = "Third", Completed = true });
                context.SaveChanges();
            }

            using (var context = new TasksContext(options))
            {
                var service = new TodoService(context);
                var todos = await service.Read();

                Assert.AreEqual(3, todos.Count());
            }
        }
    }
}