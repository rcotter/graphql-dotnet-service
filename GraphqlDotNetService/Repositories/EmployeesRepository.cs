using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService.Repositories;

public static class EmployeesRepository
{
  private static readonly Employee[] Employees = new[]
  {
      new Employee(Id: 1, CompanyId: 1, Name: "Rick", Age: 21),
      new Employee(Id: 2, CompanyId: 1, Name: "Matei", Phone: "555-555-5555"),
      new Employee(Id: 3, CompanyId: 1, Name: "Jose", Age: 45),
      new Employee(Id: 4, CompanyId: 2, Name: "Tony", Age: 39),
      new Employee(Id: 5, CompanyId: 2, Name: "Thea", Age: 7, Phone: "604-555-5555"),
      new Employee(Id: 6, CompanyId: 3, Name: "Liam"),
  };

  public static Employee[] GetCompanyEmployees(int companyId) => Employees.Where(e => e.CompanyId == companyId).ToArray();
}