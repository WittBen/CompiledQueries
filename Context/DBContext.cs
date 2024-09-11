namespace ConsoleApp1.Context;

public class DBContext : DbContext
{
  public DBContext(DbContextOptions<DBContext> options)
  : base(options)
  {
    this.EnsureSeedData(); // new line added
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseInMemoryDatabase("DataList");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(Employee).Assembly);
  }


  public DbSet<Employee> Data { get; set; }
}
