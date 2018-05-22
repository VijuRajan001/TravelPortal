using DataAccessRepository.Base;
using DataAccessRepository.Core;
using DataAccessRepository.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using TravelDesk.Auth.Implementation;
using TravelDesk.Auth.Interfaces;
using TravelDesk.Models;
using AutoMapper;
using DataAccessRepository.SeedData;

namespace Travel_Desk
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string SecretKey = "ABCneedtogetthisfromenvironmentXYZ";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(SecretKey));


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<TravDeskDbcontext>(options =>
                                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                   b => b.MigrationsAssembly("TravelDesk")));
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = System.TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("TravlDesk-NOUS", policy => policy.RequireClaim(TravelDesk.Helpers.Constants.Strings.JwtClaimIdentifiers.Rol, TravelDesk.Helpers.Constants.Strings.JwtClaims.ApiAccess));
            });


            services.AddIdentity<AppUser, IdentityRole>
               (o =>
               {
                   // configure identity options
                   o.Password.RequireDigit = false;
                   o.Password.RequireLowercase = false;
                   o.Password.RequireUppercase = false;
                   o.Password.RequireNonAlphanumeric = false;
                   o.Password.RequiredLength = 6;
               })
               .AddEntityFrameworkStores<TravDeskDbcontext>()
               .AddDefaultTokenProviders();

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            SeedData.SeedUsers(userManager);
        }
    }
}
