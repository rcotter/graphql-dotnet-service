using GraphqlDotNetService;
using GraphqlDotNetService.Dto;

var builder = WebApplication.CreateBuilder(args);

builder
   .Services
   .AddGraphQLServer()
   .AddDocumentFromFile("schema.graphql")
   .BindRuntimeType<Query>()
   .BindRuntimeType<Company>()
   .BindRuntimeType<Employee>()
   .BindRuntimeType<EmployeeAddress>()
   .BindRuntimeType<NotesA>()
   .BindRuntimeType<NotesB>()
   .AddResolver("Company", "dynamicNotes", SubgraphResolvers.GetCompanyNotes())
   .AddResolver("Company", "employees", SubgraphResolvers.GetCompanyEmployees());

var app = builder.Build();
app.MapGraphQL();
app.Run();