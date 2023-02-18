using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService;

public static class CompanyRepository
{
  public static Company[] GetCompanies() => new[]
  {
      new Company(1, Name: "Contempo Construction", Nickname: "Conny"),
      new Company(2, Name: "Flatline Deliveries"),
      new Company(3, Name: "OK Pizza", Nickname: "OK ZA")
  };
}