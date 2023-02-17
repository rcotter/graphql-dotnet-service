
# GraphQL .Net Service
A reference implementation for a bunch of GraphQL concerns.

Schema is implemented "schema first" for clear git diffs. 

## Concerns
Each will be marked done ✅

### Authentication
Really the same as any .Net app
https://chillicream.com/docs/hotchocolate/v13/security/authentication

### Authorization
Standard mechanisms: roles, policies
https://chillicream.com/docs/hotchocolate/v13/security/authorization

### Load Limiting aka Prevent Huge Queries
Mechanisms to calculate and score query complexity.
Would be implicitly applied to recursive graphs.
https://chillicream.com/docs/hotchocolate/v13/security/operation-complexity

### Pagination
GraphQL has a formal spec
https://chillicream.com/docs/hotchocolate/v13/fetching-data/pagination

### Filtering
https://chillicream.com/docs/hotchocolate/v13/fetching-data/filtering

### Sorting
https://chillicream.com/docs/hotchocolate/v13/fetching-data/sorting

### Fetching Data Source Integrations
https://chillicream.com/docs/hotchocolate/v13/integrations

### Fetching Data Aligned With Request
Projections incoming request to match database driver.
https://chillicream.com/docs/hotchocolate/v13/fetching-data/projections

### Fetching n+1 Data
Data loading
https://chillicream.com/docs/hotchocolate/v13/fetching-data/dataloader

### Dynamic Data aka Jagged Schema
Use unions to have a sub node be one of a list of understood schemas
https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/unions

A union type can be any one from a list of types.

### Instrumentation / Tracing
https://chillicream.com/docs/hotchocolate/v13/server/instrumentation

### Versioning
https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/versioning

Start with field/enum deprecation
Use @deprecated directive
https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/directives

## Schema
```
{
  "id": int,
  "name": string,
  
  // Deprecated
  "nickname": string
  [README.md](..%2FREADME.md)
  // Exercises authorization, sorting, pagination, filtering, n+1 data fetching 
  "employees": [
    "name": string,
    "phone": string, 
    "homeAddress":, { // Exercises load limiting / scoring and limiting high cost fetching
      "street": string,
      "number": string
    }
  ],
  // Exercises jagged schema / unions
  "customPerCompany": {
    ...
  }
}
```
