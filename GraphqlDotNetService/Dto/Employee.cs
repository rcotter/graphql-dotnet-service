namespace GraphqlDotNetService.Dto;

public record Employee(
    int Id,
    int CompanyId,
    String Name,
    int? Age = null,
    String? Phone = null);