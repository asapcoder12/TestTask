using TestTask.DataAccess.UnitOfWork.Interfaces;
using TestTask.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.EF;
using TestTask.Services;
using Rocky_DataAccess.Initializer;
using TestTask.DataAccess.Initializer;
using TestTask.Business.Implementations;

namespace TestTask.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Seeding Database
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();

            // UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Other services
            builder.Services.AddTransient<ICsvParser, CsvParser>();

            // BL Services
            builder.Services.AddTransient<CitizenService>();

            // AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Index");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
