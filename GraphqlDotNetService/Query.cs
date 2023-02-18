using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService;

public class Query
{
  public Company[] GetCompanies() => CompanyRepository.GetCompanies();

  // Deprecated in SDL: 'Find' is against naming convention. Will be removed 2024-01-15 after profiling usage is clear.
  public Company[] FindCompanies() => CompanyRepository.GetCompanies();

  public dynamic? GetDynamicNotes(int companyId) => NotesRepository.GetNotBaseNotesForCompany(companyId);
}