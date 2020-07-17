using Microsoft.EntityFrameworkCore;

namespace FileToDbQuestionInserter
{
    public class JeopardyContext : DbContext
    {
        public DbSet<DbJeopardyQuestion> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Round> Rounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Jeopardy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
