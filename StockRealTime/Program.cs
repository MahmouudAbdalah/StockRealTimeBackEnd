using BusinessLayer.IManager;
using BusinessLayer.Manager;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoriesLayer;
using System.Text;

namespace RealTimeStock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
            builder.Services.AddDbContext<StockRealTimeContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", cors =>
                {
                    cors.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials(); // Allow credentials for CORS
                });
            });
            builder.Services.AddSignalR();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IStockManager, StockManager>();
            builder.Services.AddScoped<IStockHistoryManager, StockHistoryManager>();
            builder.Services.AddScoped<IOrderManager, OrderManager>();
            builder.Services.AddScoped<IOrderHistoryManager, OrderHistoryManager>();
            builder.Services.AddScoped<IAccountManager, AccountManager>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            app.MapControllers();
            app.UseEndpoints(endpoints =>
    {
        endpoints.MapHub<StockHub>("/stockHub");

    });
            app.Run();
        }
    }
}
