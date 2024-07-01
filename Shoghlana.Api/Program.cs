
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shoghlana.Api.Hubs;
using Shoghlana.Api.Services.Implementaions;
using Shoghlana.Api.Services.Implementations;
using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Helpers;
using Shoghlana.Core.Interfaces;
using Shoghlana.Core.Models;
using Shoghlana.EF;
using Shoghlana.EF.Configurations;
using Shoghlana.EF.Repositories;
using Shoghlana.EF.Repository;
using System.Text;

namespace Shoghlana.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //});
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<IDictionary<string, UserRoomConnection>>(opt =>
            new Dictionary<string, UserRoomConnection>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDBContext>()
                            .AddDefaultTokenProviders();

            builder.Services.Configure<Jwt>(builder.Configuration.GetSection("JWT"));

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidIssuer = builder.Configuration["JWT:Issuer"],
                       ValidAudience = builder.Configuration["JWT:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                   };
               });

            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
            builder.Services.AddScoped<IMailService, MailService>();

            // registering Ioptions<GoogleAuthConfig>
            builder.Services.Configure<GoogleAuthConfig>(builder.Configuration.GetSection("google"));

            // Registering the Unit of work inside the application container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IClientNotificationRepository, ClientNotificationRepository>();

            builder.Services.AddScoped<IJobRepository, JobRepository>();
            builder.Services.AddScoped<IJobSkillsRepository, JobSkillsRepository>();

            builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            builder.Services.AddScoped<IFreelancerSkillsRepository, FreelancerSkillsRepository>();
            builder.Services.AddScoped<IFreelancerNotificationRepository, FreelancerNotificationRepository>();

            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IProjectImagesRepository, ProjectImagesRepository>();
            builder.Services.AddScoped<IProjectSkillsRepository, ProjectSkillsRepository>();

            builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
            builder.Services.AddScoped<IProposalImageRepository, proposalImageRepository>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<ISkillRepository, SkillRepository>();

            builder.Services.AddScoped<IRateRepository, RateRepository>();
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            // Registering the Generic Repository inside the application container.
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Registering the Generic Service inside the application container.
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            // Registering the Services inside the application container.
            builder.Services.AddScoped<IProposalService, ProposalService>();
            builder.Services.AddScoped<IProposalImageService, ProposalImageService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IFreelancerService, FreelancerService>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IRateService, RateService>();
            builder.Services.AddScoped<IProposalImageService, ProposalImageService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            // builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    //builder.AllowAnyOrigin()
                       builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


            //************************************************************************


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();  

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapHub<NotificationHub>("/notificationHub");

            app.MapHub<ChatHub>("/ChatHub");

            //app.UseEndpoints(Endpoint =>
            //{
            //    Endpoint.MapHub<ChatHub>("/CharHub");
            //});

            //app.UseAuthorization();  // why repeated here ?

            app.MapControllers();

            app.Run();
        }
    }
}
