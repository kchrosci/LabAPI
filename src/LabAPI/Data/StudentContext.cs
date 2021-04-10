using Microsoft.EntityFrameworkCore;
using LabAPI.Models;

namespace LabAPI.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }
        public DbSet<Command> StudentItems {get; set;}
    }
}