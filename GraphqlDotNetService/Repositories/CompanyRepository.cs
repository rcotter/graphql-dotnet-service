using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService.Repositories;

public static class CompanyRepository
{
  private static readonly IQueryable<Company> Companies = new List<Company>
  {
      new(1, Name: "Contempo Construction", Nickname: "Conny"),
      new(2, Name: "Flatline Deliveries"),
      new(3, Name: "OK Pizza", Nickname: "OK ZA")
  }.AsQueryable();

  public static IQueryable<Company> GetCompanies() => Companies;
}