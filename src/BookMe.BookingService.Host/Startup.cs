using System.Reflection;
using AutoMapper;
using BookMe.BookingService.Application.Commands.EventCommands;
using BookMe.BookingService.Application.Pipelines;
using BookMe.BookingService.Data;
using BookMe.BookingService.Data.Repositories.Abstractions;
using BookMe.BookingService.Domain;
using BookMe.BookingService.Host.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BookMe.BookingService.Host {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices (IServiceCollection services) {
            services.AddMediatR(Assembly.GetAssembly(typeof(CreateEventCommand)))
                .AddMediatR(typeof(LoggerPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));

            services.AddAutoMapper(Assembly.GetAssembly (typeof (Startup)));

            services.AddCors();

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext> (options =>
                options.UseSqlite (
                    Configuration.GetConnectionString ("DefaultConnection"),
                    t => t.MigrationsAssembly ("BookMe.BookingService.Host")));

            #region REPOSITORIES

            services
                .AddScoped<IGeneralRepository<Event>, GeneralRepository<Event>> ()
                .AddScoped<IGeneralRepository<Booking>, GeneralRepository<Booking>> ();

            #endregion

            // Swagger
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "Booking Service", Version = "v1" });
            });
        }

        public void Configure (IApplicationBuilder app) {
            app.UseCors (
                builder => builder
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ()
            );

            app.UseRouting();
            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Booking Service API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.PrepareDatabase ();
        }
    }
}