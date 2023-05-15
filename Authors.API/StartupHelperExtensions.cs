using Authors.API.Controllers;
using Authors.API.DbContexts;
using Authors.API.Services;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Authors.API.Helpers;

namespace CourseLibrary.API;

internal static class StartupHelperExtensions
{
    // Add services to the container
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(configure =>
        {
            configure.ReturnHttpNotAcceptable = true;
        })
        .AddNewtonsoftJson(setupAction =>
        {
            setupAction.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        });

        builder.Services.AddTransient<IPropertyMappingService, PropertyMappingService>();
        builder.Services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();
        builder.Services.AddScoped<ICourseLibraryRepository, CourseLibraryRepository>();

        builder.Services.AddHttpClient();

        builder.Services.AddDbContext<CourseLibraryContext>(options =>
        {
            options.UseSqlite(@"Data Source=library.db");
        });

       
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddSwaggerGen();

        return builder.Build();
    }

    // Configure the request/response pipelien
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
        });

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetService<CourseLibraryContext>();
                if (context != null)
                {
                    //await context.Database.EnsureDeletedAsync();
                    //await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}