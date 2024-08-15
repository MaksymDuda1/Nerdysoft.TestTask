using AnnounceBoard.API.Middlewares;
using AnnounceBoard.Application;
using AnnounceBoard.Infrastructure;
using Microsoft.Extensions.FileProviders;

namespace AnnounceBoard.API;

public static class StartupHelperExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();

        builder.Services.AddApplicationService();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("EnableCORS", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        
        /*builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:8000") // fix
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });*/

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Images")),
            RequestPath = new PathString("/Images")
        });
        app.MapControllers();
        
        return app;
    }
}