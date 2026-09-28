using BlogDataLibrary.Database;
using BlogDataLibrary.Models;
using Microsoft.Extensions.Configuration;

// Load appsettings.json configuration
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

// Instantiate data access classes
ISqlDataAccess db = new SqlDataAccess(config);
ISqlData sqlData = new SqlData(db);

Console.WriteLine("--- Testing SQL Server Connection ---");

// Test Authentication / Retrieval for your inserted record
var user = sqlData.Authenticate("kabconstantino", "2020111940");

if (user != null)
{
    Console.WriteLine($"Successfully retrieved user: {user.FirstName} {user.LastName} ({user.UserName})");
}
else
{
    Console.WriteLine("User not found or authentication failed.");
}