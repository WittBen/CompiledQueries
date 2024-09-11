namespace ConsoleApp1.Services;

public class MyService : IMyService
{
  private readonly DBContext _context;
  public MyService()
  {
    var options = new DbContextOptionsBuilder<DBContext>()
        .UseInMemoryDatabase("Checkout")
        .Options;

    _context = new DBContext(options);
  }



  #region List
  public IEnumerable<Employee> GetAllData() 
  {
    var listOfData = _context.Data.ToList();
    return listOfData;
  }

  private static readonly Func<DBContext, IEnumerable<Employee>> DataList = EF.CompileQuery((DBContext db) => db.Data.ToList());
  public IEnumerable<Employee> GetAllData_Compiled()
  {
    return DataList(_context).ToList();
  }


  private static Func<DBContext, IAsyncEnumerable<Employee>> DataListAsync = EF.CompileAsyncQuery((DBContext ctx) => ctx.Data);
  public async Task<IEnumerable<Employee>> GetAllData_Compiled_Async()
  {
      _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

      var result = new List<Employee>();
      await foreach (var s in DataListAsync(_context))
      {
        result.Add(s);
      }

      return result;
    
  }
  #endregion


  #region Single Or First
  public Employee? GetDataById(int id)
  {
    var data = _context.Data.FirstOrDefault(x=>x.Id == id);
    return data;
  }

  private static readonly Func<DBContext, int,  Employee?> DataById = EF.CompileQuery((DBContext db, int id) => db.Data.FirstOrDefault(x => x.Id == id));
  public Employee? GetDataById_Compiled(int id)
  {
    return DataById(_context, id);
  }


  private static Func<DBContext, int, Task<Employee?>> DataById_Async = EF.CompileAsyncQuery((DBContext ctx, int id) => ctx.Data.FirstOrDefault(x=>x.Id==id));
  public async Task<Employee?> GetDataById_Compiled_Async(int id)
  {
    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    return await DataById_Async(_context, id);

  }
  #endregion

}