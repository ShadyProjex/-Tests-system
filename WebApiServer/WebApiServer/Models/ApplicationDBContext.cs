using Microsoft.EntityFrameworkCore;

namespace WebApiServer.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
    : base(options)
        { }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExam> UsersExams { get; set; }
    }
}
