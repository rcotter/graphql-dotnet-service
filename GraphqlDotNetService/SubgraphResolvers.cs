using GraphqlDotNetService.Dto;
using HotChocolate.Resolvers;

namespace GraphqlDotNetService;

// Resolvers for nested nodes of the graph. 'Query' handles root resolvers.
// There must be a better pattern for all of this.
public static class SubgraphResolvers
{
  public static Func<IResolverContext, object?> GetCompanyNotes() => (context) => new Query().GetDynamicNotes(
                                                                      GetParentCompany(context).Id);

  public static Func<IResolverContext, object?> GetCompanyEmployees() => (context) => new Query().GetEmployees(
                                                                          GetParentCompany(context).Id);

  public static Func<IResolverContext, object?> GetEmployeeAddress() => (context) => new Query().GetEmployeeAddress(
                                                                         GetParentEmployee(context).Id);

  private static Company GetParentCompany(IResolverContext context) => context.Parent<Company>();

  private static Employee GetParentEmployee(IResolverContext context) => context.Parent<Employee>();
}