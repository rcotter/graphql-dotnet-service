using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService.Repositories;

public static class CompanyRepository
{
  private static readonly Company[] Companies = new[]
  {
      new Company(1, Name: "Contempo Construction", Nickname: "Conny"),
      new Company(2, Name: "Flatline Deliveries"),
      new Company(3, Name: "OK Pizza", Nickname: "OK ZA")
  };

  public static Company[] GetCompanies() => Companies;
}