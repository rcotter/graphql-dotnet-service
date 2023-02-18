namespace GraphqlDotNetService.Dto;

public record NotesB(int CompanyId, String Thoughts, String ImageUrl) : BaseNotes(CompanyId);