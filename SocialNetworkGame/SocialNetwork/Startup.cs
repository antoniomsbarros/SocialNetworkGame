using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.infrastructure;
using SocialNetwork.core.model.shared;
using SocialNetwork.infrastructure.persistence.Shared;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.core.model.relationships.repository;
using SocialNetwork.core.model.systemUsers.repository;
using SocialNetwork.core.model.tags.repository;
using SocialNetwork.core.services.connectionRequests;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.relationships;
using SocialNetwork.core.services.systemUsers;
using SocialNetwork.core.services.tags;
using SocialNetwork.infrastructure.persistence.connectionRequests;
using SocialNetwork.infrastructure.persistence.players;
using SocialNetwork.infrastructure.persistence.relationships;
using SocialNetwork.infrastructure.persistence.systemUsers;
using SocialNetwork.infrastructure.persistence.tags;

namespace SocialNetwork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SocialNetworkDbContext>(options =>
                options
                    .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>()
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            ConfigureMyServices(services);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1); // Cookie expires in 1 day
                options.Cookie.Name = "SocialNetworkGameCookie";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
                //.WithOrigins("http://localhost:4200", "https://localhost:4200")
                .AllowAnyMethod()
               // .AllowCredentials()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ISystemUserRepository, SystemUserRepository>();
            services.AddTransient<SystemUserService>();

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<PlayerService>();

            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<TagsService>();

            services.AddTransient<IIntroductionRequestRepository, IntroductionRequestRepository>();
            services.AddTransient<IntroductionRequestService>();

            services.AddTransient<IDirectRequestRepository, DirectRequestRepository>();
            services.AddTransient<DirectRequestService>();

            services.AddTransient<IRelationshipRepository, RelationshipRepository>();
            services.AddTransient<RelationshipService>();
        }
    }
}