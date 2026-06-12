
using CW21.Presentation.Data;
using CW21.Presentation.Service;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiPresention.Filters;

namespace WebApiPresention
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin() // ????? ?? ??? ??????
                    .AllowAnyMethod() // ????? ?? ??? ????? (GET, POST, etc.)
                    .AllowAnyHeader(); // ????? ?? ??? ?????
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDBConnection")));

            builder.Services.AddScoped<TagService>();
            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<ClientDetail>();
            builder.Services.AddControllers(option => {
                option.Filters.Add<ClientDetail>();
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseCors("AllowAll");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<SendProgramToSiteMiddleware>();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseMiddleware<IPAuthenticationMiddleware>();

            app.MapGet("/",() => "Success"); 

            app.MapControllers();

            app.Run();
        }
    }
}
