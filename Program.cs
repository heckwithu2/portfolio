using portfolioApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

if (builder.Environment.IsDevelopment()) {
builder.Services.AddDbContext<portfolioApiContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );
} else {
    builder.Services.AddDbContext<portfolioApiContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
    );
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
        //configured in the appsettings.json
        options.HttpsPort = 443;
    });
}


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
    //options.ExcludedHosts.Add("example.com");
    //options.ExcludedHosts.Add("www.example.com");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseExceptionHandler("/notdevelopment");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


