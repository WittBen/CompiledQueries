using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Benchmark
{

  [MemoryDiagnoser]
  public class Benchmarking
  {

    [Benchmark]
    public List<Employee> EF_Statement()
    {
      var serviceProvider = new ServiceCollection().AddTransient<IMyService, MyService>().BuildServiceProvider();
      var service = serviceProvider.GetService<IMyService>()!;

      return service.GetAllData().ToList();
    }


    [Benchmark]
    public List<Employee> EF_Statement_Compiled()
    {
     
        var serviceProvider = new ServiceCollection().AddTransient<IMyService, MyService>().BuildServiceProvider();
        var service = serviceProvider.GetService<IMyService>()!;

      return  service.GetAllData_Compiled().ToList(); 
     
    }


    [Benchmark]
    public Employee? EF_Statement_ByID()
    {

      var serviceProvider = new ServiceCollection().AddTransient<IMyService, MyService>().BuildServiceProvider();
      var service = serviceProvider.GetService<IMyService>()!;

      return service.GetDataById(2);

    }

    [Benchmark]
    public Employee? EF_Statement_ByID_Compiled()
    {

      var serviceProvider = new ServiceCollection().AddTransient<IMyService, MyService>().BuildServiceProvider();
      var service = serviceProvider.GetService<IMyService>()!;

      return service.GetDataById_Compiled(2);

    }

    [Benchmark]
    public async Task<Employee?> EF_Statement_ByID_Async_Compiled()
    {

      var serviceProvider = new ServiceCollection().AddTransient<IMyService, MyService>().BuildServiceProvider();
      var service = serviceProvider.GetService<IMyService>()!;

      return await service.GetDataById_Compiled_Async(2);

    }
  }
 
}
