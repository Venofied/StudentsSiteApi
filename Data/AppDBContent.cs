using Microsoft.EntityFrameworkCore;
using WebAPITask_1.Data.Models;

namespace WebAPITask_1.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Group> Group { get; set; }

    }
}
