# Tips Core Net

Silly tips for techies that cannot figure out where the problem is.
The idea of this project is admittedly inspired by [forse](https://github.com/mattiapiccinetti/forse) by [@mattiapiccinetti](https://github.com/mattiapiccinetti), although it is implemented with different technologies.

## Why?

Just having fun playing with .NET Core (2.0 preview) and AngularJS (1.x).

## How to run the projects

You will need .NET Core 2.0 preview installed on your machine.

```bash
# Run the Api
cd Tips.Api.Service
dotnet restore
dotnet run

# Run the Web App
cd Tips.Web.Service
dotnet restore
dotnet run

# Browse http://localhost:8080
# Browse http://localhost:8080/admin to add/edit/delete some tips
```
