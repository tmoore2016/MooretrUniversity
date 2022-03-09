/*Install-Package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
 *  Required packages:
 *  dotnet add package Microsoft.EntityFrameworkCore.Sqlite
 *  dotnet add package Microsoft.EntityFrameworkCore.Design
 *  dotnet tool install --global dotnet-ef
 *  dotnet tool update --global dotnet-ef
 *  
*/

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MooretrUniversity.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

// Add helpful error information in the development environment for EF migration errors
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // Enable error reporting
    app.UseMigrationsEndPoint();
}

// To remove the local database:
// Package manager console: Drop-Database -Confirm
// Migration commands:
// PMC: Add-Migration InitialCreate // initial commit
// PMC: Update-Database
// PMC: Add-Migration NameLengthValidation // database change
// PMC: Update-Databse
// PMC: remove-migration
// See Migrations\timestamp_InitialCreate.cs after creation,
// also SQL Server Object Explorer, "_EFMigrationsHistory"
// table for migration history
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SchoolContext>();

    // Create the database if it doesn't exist. This overwrites all data so only useful during development. To preserve data, use migrations instead
    //context.Database.EnsureCreated();

    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
