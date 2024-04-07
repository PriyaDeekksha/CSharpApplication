using Microsoft.EntityFrameworkCore;
using WebApplication11.model;

namespace WebApplication11.Data
{
    public class StadiumAPIDbContext:DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public StadiumAPIDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public DbSet<Stadium> Stadium { get; set; }

       
    }
   
}
