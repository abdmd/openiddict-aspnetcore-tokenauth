## Openiddict token-based auth using Asp.Net Core 1.1 and MySQL

### Setup:

1. Install **.NET Core 1.1** (*.NET Core 1.0.3 SDK - [Installer]()*)
2. Restore nuget packages
3. Specify MySQL connection string in `web.config`
4. `Add-Migration` *{MigrationName}* in PM console, or dotnet ef migrations add *{MigrationName}* using Dotnet-CLI
5. `Update-Database`, or *dotnet ef database update* using Dotnet-CLI

### Test:

1. Use the seeded *admin* user to validate tokens, check `ApplicationDbContext.cs`.

2. Get Token: Send a POST request to `http://localhost:xxxx/connect/token`
   * grant_type=password
   * username=admin[at]test[.]com
   * password=Test1234%

   You will receive the token in response from server.


3. Access protected routes: Add `Authorization` field in the header of request and set value to `Bearer`  + token.

##### Reference: 
* [Openiddict Password Flow sample](https://github.com/openiddict/openiddict-samples/tree/master/samples/PasswordFlow)
* [ASP.NET Core Token Authentication Guide](https://stormpath.com/blog/token-authentication-asp-net-core)