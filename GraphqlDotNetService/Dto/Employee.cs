namespace GraphqlDotNetService.Dto;

public record Employee(
    int Id,
    String Name,
    int? Age,
    String? Phone);