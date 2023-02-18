namespace GraphqlDotNetService.Dto;

public record NotesA(int CompanyId, String Text) : BaseNotes(CompanyId);