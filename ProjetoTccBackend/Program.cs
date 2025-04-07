using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ApiEstoqueASP.Services;
using ProjetoTccBackend.Database;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories;
using ProjetoTccBackend.Repositories.Interfaces;
using ProjetoTccBackend.Services;
using ProjetoTccBackend.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using ProjetoTccBackend.Middlewares;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Hubs;

namespace ProjetoTccBackend
{
    public class ProjetoTccBackend
    {
        /// <summary>
        /// Cria as funções padrão no sistema se elas não existirem.
        /// </summary>
        /// <param name="serviceProvider">Provedor de serviços para obter os gerenciadores de função e usuário.</param>
        /// <returns>Uma tarefa assíncrona.</returns>
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "Admin", "Student", "Teacher" };

            IdentityResult roleResult;

            foreach (string roleName in roleNames)
            {
                bool roleExist = await roleManager.RoleExistsAsync(roleName);
                if (roleExist is false)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private static void ConfigureWebSocketOptions(WebApplication app)
        {
            var options = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromMinutes(2),
                AllowedOrigins = { "http://localhost:3000" }
            };

            app.UseWebSockets(options);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            //builder.Services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});

            // Add services to the container.
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddDbContext<TccDbContext>();
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 8;
            })
                .AddEntityFrameworkStores<TccDbContext>()
                .AddDefaultTokenProviders();

            // Repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IExerciseInputRepository, ExerciseInputRepository>();
            builder.Services.AddScoped<IExerciseOutputRepository, ExerciseOutputRepository>();
            builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

            // Services
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<IExerciseService, ExerciseService>();
            builder.Services.AddScoped<IGroupAttemptService, GroupAttemptService>();

            builder.Services.AddSignalR();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"]!)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            /*
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("StudentUser", policy => policy.AddRequirements(new StudentUserRole());
            });
            */



            var app = builder.Build();

            CreateRoles(app.Services.CreateScope().ServiceProvider!).GetAwaiter().GetResult();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            ConfigureWebSocketOptions(app);

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<CompetitionHub>("/hub/competition");

            app.Run();
        }
    }
}
