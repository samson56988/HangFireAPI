using Microsoft.EntityFrameworkCore;
using HangFireAPI.Models;

namespace HangFireAPI.Models

{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Person> Persons  => Set<Person>();
    }
}
