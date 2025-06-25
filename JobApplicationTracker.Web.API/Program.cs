using Microsoft.EntityFrameworkCore;
using Application.Services.Interface;
using Application.Services.Implementation;
using Infrastructure.Repositories;
using Application.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Job Application Tracker API",
                    Description = "An ASP.NET Core Web API for managing job applications",
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services
                .AddDbContext<Infrastructure.Data.ApplicationDbContext>
                (options => options.UseInMemoryDatabase("JobApplicationDB"));

            builder.Services.
                AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services
                .AddScoped<IJobApplicationService, JobApplicationService>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.MapControllers();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseRouting();

            app.Run();
        }

    }
}
