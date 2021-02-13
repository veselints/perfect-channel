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
        private DbContextOptions<TasksContext> _options;

        public TodoServiceTests()
        {
            _options = new DbContextOptionsBuilder<TasksContext>()
                .UseInMemoryDatabase(databaseName: "MockDb")
                .Options;
        }

        [Test]
        public async Task Read_Returns_Result()
        {
            int initialCount;

            using (var context = new TasksContext(_options))
            {
                initialCount = context.Todos.Count();

                context.Todos.Add(new Todo() { ID = 1, Description = "First", Completed = true });
                context.Todos.Add(new Todo() { ID = 2, Description = "Second", Completed = true });
                context.Todos.Add(new Todo() { ID = 3, Description = "Third", Completed = true });
                context.SaveChanges();
            }

            using (var context = new TasksContext(_options))
            {
                var service = new TodoService(context);
                var todos = await service.Read();

                Assert.AreEqual(initialCount + 3, todos.Count());
            }
        }

        [Test]
        public async Task Create_Adds_Entity_To_Db()
        {
            int initialCount;

            using (var context = new TasksContext(_options))
            {
                initialCount = context.Todos.Count();

                var service = new TodoService(context);
                await service.Create("sample descr");
            }

            using (var context = new TasksContext(_options))
            {
                Assert.AreEqual(initialCount + 1, context.Todos.Count());
            }
        }

        [Test]
        public async Task Create_Adds_ID_To_Entity()
        {
            using (var context = new TasksContext(_options))
            {
                var service = new TodoService(context);
                var todoViewModel = await service.Create("sample descr");

                Assert.IsNotNull(todoViewModel.ID);
            }
        }

        [Test]
        public async Task Create_Returns_ViewModel()
        {
            using (var context = new TasksContext(_options))
            {
                var service = new TodoService(context);
                var todoViewModel = await service.Create("sample descr");

                Assert.AreEqual("sample descr", todoViewModel.Description);
            }
        }
    }
}