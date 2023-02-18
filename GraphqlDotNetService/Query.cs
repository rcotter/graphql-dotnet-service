using GraphqlDotNetService.Dto;
using GraphqlDotNetService.Repositories;

namespace GraphqlDotNetService;

public class Query
{
  [UsePaging]
  public IQueryable<Company> GetCompanies() => CompanyRepository.GetCompanies();

  // Deprecated in SDL: 'Find' is against naming convention. Will be removed 2024-01-15 after profiling usage is clear.
  public Company[] FindCompanies() => CompanyRepository.GetCompanies().ToArray();

  public dynamic? GetDynamicNotes(int companyId) => NotesRepository.GetCompanyNotes(companyId);

  public Employee[] GetEmployees(int companyId) => EmployeesRepository.GetCompanyEmployees(companyId);

  public EmployeeAddress? GetEmployeeAddress(int employeeId) =>
      EmployeeAddressesRepository.GetEmployeeAddress(employeeId);
}