using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService;

public class Query
{
  public Company[] GetCompanies() => new[]
  {
      new Company(1, Name: "Contempo Construction", Nickname: "Conny"),
      new Company(2, Name: "Flatline Deliveries"),
      new Company(3, Name: "OK Pizza", Nickname: "OK ZA")
  };

  // Deprecated: 'Find' is against naming convention. Will be removed 2024-01-15 after profiling usage is clear.
  public Company[] FindCompanies() => GetCompanies();

  public dynamic? GetDynamicNotes(int companyId) => NotesRepository.GetNotBaseNotesForCompany(companyId);
}