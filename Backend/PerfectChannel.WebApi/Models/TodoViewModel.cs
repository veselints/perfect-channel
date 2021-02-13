using System.ComponentModel.DataAnnotations;

namespace PerfectChannel.WebApi.Models
{
	public class TodoViewModel
	{
		public int ID { get; set; }

		[Required]
		public string Description { get; set; }

		public bool Completed { get; set; }

		public Todo ToEntity() => new Todo() { ID = ID, Description = Description, Completed = Completed };
	}
}
