namespace GraphqlDotNetService;

public class Query
{
  public Book GetBook() => new Book(title: "A long hard road");
}