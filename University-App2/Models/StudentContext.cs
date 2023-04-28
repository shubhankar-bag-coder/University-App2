using System.Data.Entity;

namespace University_App2.Models
{
    public class StudentContext: DbContext
    {
        public DbSet<Student>Students { get; set; }
        public DbSet<Professors> Professors { get; set; }

    }
}