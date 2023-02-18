using GraphqlDotNetService.Dto;

namespace GraphqlDotNetService;

public static class NotesRepository
{
  private static readonly BaseNotes[] AllNotes =
  {
      new NotesA(CompanyId: 1, Text: "A very nice company"),
      new NotesB(CompanyId: 2, Thoughts: "A very bad company", ImageUrl: "http://example.com/logo.png")
  };

  public static BaseNotes? GetNotBaseNotesForCompany(int companyId) =>
      AllNotes.FirstOrDefault(n => n.CompanyId == companyId);
}