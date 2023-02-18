using GraphqlDotNetService.Dto;
using HotChocolate.Resolvers;

namespace GraphqlDotNetService;

// Resolvers for nested nodes of the graph. 'Query' handles root resolvers.
// There must be a better pattern for all of this.
public static class SubgraphResolvers
{
  public static Func<IResolverContext, object?> GetDynamicNotes() => (context) =>
                                                                     {
                                                                       var company = context.Parent<Company>();
                                                                       return new Query().GetDynamicNotes(
                                                                        company.Id);
                                                                     };
}