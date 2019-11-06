using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Petshop.Infrastructure.Data;
using Petshop.Infrastructure.SQL;
using Petshop.Infrastructure.SQL.Repositories;
using PetshopCompulsory.Core.ApplicationService;
using PetshopCompulsory.Core.ApplicationService.Impl;
using PetshopCompulsory.Core.DomainService;
using PetshopCompulsory.Core.Helper;

namespace PetshopCompulsory.RestAPI
{
    public class Startup
    {
        IDbInitializer _db;
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            _db = new DbInitializer();
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JWTSecurityKey.Key,
                    ValidateLifetime = true, //validate the expiration are not before values in token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            // services.AddScoped<I, PetRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorService, ColorService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlite(
                        "Data Source=PetShop.db"));
            }
            else
            {
                services.AddDbContext<PetShopContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString(
                    "defaultConnection")));
            }
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 2;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // FakeDB.InitDataPet();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    _db.SeedDb(ctx);
                }
                app.UseDeveloperExceptionPage();

            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
                    ctx.Database.EnsureCreated();
                    if (ctx.Pets.Any())
                    {
                        _db.SeedDb(ctx);
                    }
                }
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
