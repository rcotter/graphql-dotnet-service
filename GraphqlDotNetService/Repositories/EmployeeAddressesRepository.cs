using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService.Repositories;

public static class EmployeeAddressesRepository
{
  private static readonly EmployeeAddress[] Addresses = new[]
  {
      new EmployeeAddress(Id: 1, EmployeeId: 1, Street: "Front", Number: "123"),
      new EmployeeAddress(Id: 2, EmployeeId: 3, Street: "Main", Number: "456"),
  };

  public static EmployeeAddress? GetEmployeeAddress(int employeeId) =>
      Addresses.FirstOrDefault(a => a.EmployeeId == employeeId);
}