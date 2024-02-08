using Microsoft.EntityFrameworkCore;
using NorthwindWebMvc.Basic.Models;

namespace NorthwindWebMvc.Basic.RepositoryContext
{
	public class RepositoryDbContext : DbContext
	{
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
