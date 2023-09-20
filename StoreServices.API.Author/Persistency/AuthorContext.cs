using Microsoft.EntityFrameworkCore;

namespace StoreServices.API.Author.Persistency
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options){}
        public DbSet<Models.Author>? Authors { get; set; }
        public DbSet<Models.AcademicGrade>? AcademicGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Author>()
                .Property(a => a.BirthDate)
                .HasColumnType("timestamp without time zone");
        }
    }
}