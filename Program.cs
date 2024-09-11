using BenchmarkDotNet.Attributes;

var serviceProvider = new ServiceCollection().AddTransient<IMyService, MyService>().BuildServiceProvider();
var service = serviceProvider.GetService<IMyService>()!;

Console.WriteLine("*********************  Data  **********************");
foreach (var data in service.GetAllData())
{
  Console.WriteLine($"ID: {data.Id} | FirstName:{data.FirstName} | LastName:{data.LastName} | Deparment:{data.Department} | EntryYear:{data.EntryYear}");
}

Console.WriteLine("***********************************************************");

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");


Console.WriteLine("*********************  Data compiled  **********************");
foreach (var data in service.GetAllData_Compiled())
{
  Console.WriteLine($"ID: {data.Id} | FirstName:{data.FirstName} | LastName:{data.LastName} | Deparment:{data.Department} | EntryYear:{data.EntryYear}");
}
Console.WriteLine("***********************************************************");


Console.WriteLine("*********************  Data compiled async **********************");

var ListOfEmployee = await service.GetAllData_Compiled_Async();

foreach (var data in ListOfEmployee)
{
  Console.WriteLine($"ID: {data.Id} | FirstName:{data.FirstName} | LastName:{data.LastName} | Deparment:{data.Department} | EntryYear:{data.EntryYear}");
}
Console.WriteLine("***********************************************************");



var result1 = service.GetDataById(2);

Console.WriteLine("*********************  result1 **********************");
Console.WriteLine($"ID: {result1!.Id} | FirstName:{result1.FirstName} | LastName:{result1.LastName} | Deparment:{result1.Department} | EntryYear:{result1.EntryYear}");
Console.WriteLine("***********************************************************");

var result2 = service.GetDataById_Compiled(2);
Console.WriteLine("*********************  result2 compiled **********************");
Console.WriteLine($"ID: {result2!.Id} | FirstName:{result2.FirstName} | LastName:{result2.LastName} | Deparment:{result2.Department} | EntryYear:{result2.EntryYear}");
Console.WriteLine("***********************************************************");

var result3 = await service.GetDataById_Compiled_Async(2);
Console.WriteLine("*********************  result2 async compiled **********************");
Console.WriteLine($"ID: {result3!.Id} | FirstName:{result3.FirstName} | LastName:{result3.LastName} | Deparment:{result3.Department} | EntryYear:{result3.EntryYear}");
Console.WriteLine("***********************************************************");

Console.ReadKey();

////##########################################
////!!!! switch the project to "RELEASE"  !!!!
////##########################################
//BenchmarkRunner.Run<Benchmarking>();