using API.Data;
using API.Services.CharacterService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region ConnectionString
            builder.Services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            #region SwaggerAuthorization
            builder.Services.AddSwaggerGen(c =>
                {
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = """Strang Authorization header useing the Bearer scheme. Example: "bearer {token}" """,
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });

                    c.OperationFilter<SecurityRequirementsOperationFilter>();
                }); 
            #endregion

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();


            #region JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                    .GetBytes(builder.Configuration.GetSection("AppSetting:Token").Value!)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion
            builder.Services.AddHttpContextAccessor();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}