using GraphqlDotNetService.Dto;
using HotChocolate.Resolvers;

namespace GraphqlDotNetService;

// Resolvers for nested nodes of the graph. 'Query' handles root resolvers.
// There must be a better pattern for all of this.
public static class SubgraphResolvers
{
  public static Func<IResolverContext, object?> GetCompanyNotes() => (context) => new Query().GetDynamicNotes(
                                                                      getParentCompany(context).Id);

  public static Func<IResolverContext, object?> GetCompanyEmployees() => (context) => new Query().GetEmployees(
                                                                          getParentCompany(context).Id);

  private static Company getParentCompany(IResolverContext context) => context.Parent<Company>();
}