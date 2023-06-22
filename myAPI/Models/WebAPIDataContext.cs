using System;
using Microsoft.EntityFrameworkCore;

namespace myAPI.Models
{
	public class WebAPIDataContext : DbContext 
	{

        public WebAPIDataContext(DbContextOptions<WebAPIDataContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}

