
# GraphQL .Net Reference Service 2023
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

### ✅ Pagination
GraphQL has a [formal spec](https://relay.dev/graphql/connections.htm) as implemented by [HotChocolate](https://chillicream.com/docs/hotchocolate/v13/fetching-data/pagination).
On first read it is a little dense but upon understanding that the terms **edge** and
**node** come from the world of graphs (duh!) it makes more sense. Only after a careful 
read of the whole design does the complexity of it make sense. A nicely written client
like [Strawberry Shake for .Net](https://chillicream.com/docs/strawberryshake/v13), 
Apollo's own [client](https://github.com/apollographql/apollo-client) will hide all of this 
and make it friendly again. Most other languages have them as well.

That said, HotChocolate makes setting up paging dead simple. Just add the `[UsePaging]`
attribute and it runs. Notably an important statement is:
```text
For the UsePaging middleware to work, our resolver needs to return an 
IEnumerable<T> or an IQueryable<T>. The middleware will then apply 
the pagination arguments to what we have returned. In the case of 
an IQueryable<T> this means that the pagination operations can be 
directly translated to native database queries.
```

Example usage where we ask for the next 2 companies after cursor "MQ==" (which 
we received in `endCursor` on a previous query).
```graphql
{
    companies(first: 2, after: "MQ==") {
        edges {
            cursor
            node {
                id
                name
            }
        }
        pageInfo {
            endCursor
            hasNextPage
        }
    }
}
```

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
The following use of unions would work well in many scenarios. Alterntatively there is the following approach to explore.
***TODO Explore https://youtu.be/wODiVDT8ECI***

In the **schema.graphql** file see `Company -> dynamicNotes: Notes` where `union Notes = NotesA | NotesB`.
[Unions](https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/unions) let a sub node be one 
of a list of understood schemas. Removing handling or a particular notes type will 
result in an empty hash when encountered.

Example query:
```graphql
{
  companies {
    id
    name
    dynamicNotes {
      ... on NotesA {
        text
      }
      ... on NotesB {
        thoughts
        imageUrl
      }
    }
  }
}
```

### Instrumentation / Tracing
https://chillicream.com/docs/hotchocolate/v13/server/instrumentation

### ✅ Versioning
[Versioning](https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/versioning) handled by careful and slow deprecation
before removal.

See the use of the [`@deprecated`](https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/directives) directive
as demonstrated on the `Company -> nickname` field and the `findCompanies` query.

### Try out MongoDb
https://chillicream.com/docs/hotchocolate/v13/integrations/mongodb

### Add a mutation
https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/mutations/

## Schema
```
{
  "id": int,
  "name": string,
  
  // Deprecated
  "nickname": string

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
  "dynamicNotes": {
    ...
  }
}
```
