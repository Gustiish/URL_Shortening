
using Microsoft.EntityFrameworkCore;
using URL_Shortening.DataAccessLogic;
using URL_Shortening.Database;
using URL_Shortening.Services;

namespace URL_Shortening
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IShortUrlService, ShortUrlService>();
            builder.Services.AddScoped<IUrlBuilder, UrlBuilder>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
