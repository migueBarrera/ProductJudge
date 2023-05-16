namespace ProductJudge.API.Repository;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        //for mock
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<UserTable>? Users { get; set; }
}
