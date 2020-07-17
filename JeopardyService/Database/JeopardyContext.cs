using JeopardyService.Models;
using Microsoft.EntityFrameworkCore;

namespace JeopardyService.Database
{
    public class JeopardyContext : DbContext
    {
        public JeopardyContext(DbContextOptions<JeopardyContext> options) : base(options)
        { }

        public DbSet<JeopardyQuestion> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Round> Rounds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetValidCategoriesByRoundResult>()
                .HasNoKey();

            modelBuilder.Entity<GetQuestionsByCategoryResult>()
                .HasNoKey();
        }
    }
}
