using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsService.DataAccess.EF;
using Microsoft.AspNetCore.Builder;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EventsService.Init;
using Microsoft.EntityFrameworkCore;
using EventsService.Commands;
using EventsService.Domain;
using AuthService.Api.Domain;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EventsService.DataAccess;

namespace EventsService
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
            services.AddDbContext<EbkEventDbContextFinal3_>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("PapaConnection")));
            services.AddEFConfiguration(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(JsonOptions);

            services.AddMediatR(typeof(CreateDraftEventHandler));
           // services.AddMediatR(typeof(SubscribeEventHandler));
            services.AddScoped(typeof(ISessionRepository), typeof(SessionRepository));
            services.AddScoped(typeof(IAtendeeRepository), typeof(AtendeeRepository));
            services.AddScoped(typeof(ISpeakerRepository), typeof(SpeakerRepository));
            services.AddScoped(typeof(ISponsorRepository), typeof(SponsorRepository));
            services.AddScoped(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionRepository));
            services.AddScoped(typeof(IResourceRepository), typeof(ResourceRepository));
            services.AddScoped(typeof(IResourceRepository), typeof(ResourceRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IEventBag), typeof(BagRepository));
            services.AddScoped(typeof(IMessageRepository), typeof(MessageRepository));
            services.AddEventEventInitializer();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseInitializer();
            app.UseAuthentication();
           // app.UseAuthorization();
        }
            private void JsonOptions(MvcJsonOptions options)
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }
        }
    }

