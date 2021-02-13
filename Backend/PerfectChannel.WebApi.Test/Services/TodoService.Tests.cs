using Moq;
using NUnit.Framework;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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
            Random rand = new Random();
            int initialCount;

            using (var context = new TasksContext(_options))
            {
                initialCount = context.Todos.Count();

                context.Todos.Add(new Todo() { ID = rand.Next(), Description = "First", Completed = true });
                context.Todos.Add(new Todo() { ID = rand.Next(), Description = "Second", Completed = true });
                context.Todos.Add(new Todo() { ID = rand.Next(), Description = "Third", Completed = true });
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

        [Test]
        public void Update_Updates_Todo()
        {
            var rand = new Random().Next();

            using (var context = new TasksContext(_options))
            {
                context.Todos.Add(new Todo() { ID = rand, Description = "First", Completed = false });
                context.SaveChanges();
            }

            using (var context = new TasksContext(_options))
            {
                context.Update(new Todo() { ID = rand, Description = "First", Completed = true });

                Assert.AreEqual(context.Todos.FirstOrDefault(f => f.ID == rand).Completed, true);
            }
        }
    }
}