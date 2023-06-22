using System;

namespace myAPI.Models
{
	public class Book
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Author { get; set; }

		public decimal Price { get; set; }

		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

	}


}

