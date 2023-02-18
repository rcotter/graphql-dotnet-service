namespace GraphqlDotNetService.Dto;

public record EmployeeAddress(
    int Id,
    int EmployeeId,
    string Street,
    string Number);