using PerfectChannel.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Data
{
	public class DbInitializer
	{
        public static void Initialize(TasksContext context)
        {
            context.Database.EnsureCreated();

            if (context.Todos.Any())
            {
                return;
            }

            var todos = new Todo[]
            {
                new Todo() { Description = "First", Completed = true },
                new Todo() { Description = "Second", Completed = true },
                new Todo() { Description = "Third", Completed = true },
                new Todo() { Description = "Forth", Completed = false },
                new Todo() { Description = "Fifth", Completed = false }
            };

            foreach (Todo t in todos)
            {
                context.Todos.Add(t);
            }

            context.SaveChanges();
        }

        public static void Clear(TasksContext context)
        {
            context.Database.EnsureCreated();

            context.Todos.RemoveRange(context.Todos.ToList());

            context.SaveChanges();
        }
    }
}
