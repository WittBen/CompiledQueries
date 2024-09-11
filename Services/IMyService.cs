using System.Xml.Linq;

namespace ConsoleApp1.Services;

public interface IMyService
{
  IEnumerable<Employee> GetAllData();
  IEnumerable<Employee> GetAllData_Compiled();
  Task<IEnumerable<Employee>> GetAllData_Compiled_Async();

  Employee? GetDataById(int id);
  Employee? GetDataById_Compiled(int id);
  Task<Employee?> GetDataById_Compiled_Async(int id);
}