namespace GraphqlDotNetService.Dto;

public record Company(
    int Id,
    String Name,
    String? Nickname = null)
{
    public string[] Employees { get; init; } = Array.Empty<string>();
}