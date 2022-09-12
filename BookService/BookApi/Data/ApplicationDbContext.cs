using BookApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Books> BookTbl { get; set; }
    }
}
