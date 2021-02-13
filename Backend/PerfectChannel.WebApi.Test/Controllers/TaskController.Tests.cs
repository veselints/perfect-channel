using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PerfectChannel.WebApi.Controllers;
using PerfectChannel.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Test.Controllers
{
    public class TaskControllerTests
    {
        private Mock<ITodoService> _service;
        private TaskController _controller;


        public TaskControllerTests()
        {
            _service = new Mock<ITodoService>();
            _controller = new TaskController(_service.Object);
        }

        [Test]
        public async Task Read_Action_Returns_Result()
        {
            var todos = new List<TodoViewModel>
        {
            new TodoViewModel() { Description = "First", Completed = true },
            new TodoViewModel() { Description = "Second", Completed = true },
            new TodoViewModel() { Description = "Third", Completed = true },
            new TodoViewModel() { Description = "Forth", Completed = false },
            new TodoViewModel() { Description = "Fifth", Completed = false }
        };

            _service.Setup(s => s.Read()).ReturnsAsync(todos.AsEnumerable());

            var result = await _controller.Get() as JsonResult;
            var value = result.Value as IEnumerable<TodoViewModel>;

            Assert.AreEqual(value.Count(), 5);
        }
    }
}