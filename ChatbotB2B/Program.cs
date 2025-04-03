using Application.Common.BCryptHasher;
using Application.Common.BCryptHasher.Interface;
using Application.CompanyAggregate.Respositories.Interfaces;
using Infraestructure.Common.Entities;
using Infraestructure.SqlServer.CompanyRepository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        builder.Services.AddScoped(context => new SqlSettings
        {
            ConnectionString = "Data Source=ROTEADOR;Initial Catalog=ChatbotB2B;Integrated Security=False;User ID=sa;Password=123;MultipleActiveResultSets=true;TrustServerCertificate=true",
        });

        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}