# BookService

Is a .NET Framework Web API project with underlying SQL Server database as a persistent layer and Entity Framework ORM.

## DB Setup

To create db in LocalDB and seed it with initial data run from the Package Manager Console
```
update-database
```

## Developer setup

```
git clone git@github.com:puhnastik/BookService.git
cd BookService
msbuild
```

## Tests

Unit tests can be under under tests folder.
Postman collection in the root directory can be used to excersice API calls.
