using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpsPolicy;
using Swashbuckle.AspNetCore.Swagger;
using AuthenticationApi.DbContexts;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using AuthenticationApi.IRepositories;
using AuthenticationApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using AuthenticationApi.MappingModels;
using Serilog;

namespace AuthenticationApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
             .ReadFrom.Configuration(configuration, Globals.SerilogConfigSection)
             .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "AB&Tacrmac AZure",
                    Version = "v"
                });
                // To Enable authorization using Swagger (JWT)
                x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });


            /* Jwt Authentication start here */



            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JsW:ww"],
                    ValidIssuer = Configuration["JsW:ww"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JsW:ke"]))
                };
            });

            /* Jwt Authentication Ends here */

            services.AddCors(o => o.AddPolicy("cors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
          
            services.AddTransient(typeof(IToken), typeof(TokenImp));
            services.AddTransient(typeof(IGenToken), typeof(GenTokenImp));
            services.AddTransient(typeof(ILogTBL), typeof(LogTBLImp));
            services.AddTransient(typeof(IUsers), typeof(UsersImp));
            services.AddTransient(typeof(IEmailSender), typeof(EmailSenderImp));
            services.AddTransient(typeof(IOnboardActivationDetails), typeof(OnboardActivationDetailsImp));
            services.AddTransient(typeof(IOnboardActivation), typeof(OnboardActivationImp));
            services.AddTransient(typeof(IWemaBankVirtualAccount ), typeof(WemaBankVirtualAccountImp));
            services.AddTransient(typeof(ITransactions), typeof(Transactions));
            services.AddTransient(typeof(IMsPlug), typeof(MsPlugImp));
            services.AddTransient(typeof(IPinSettings), typeof(PinSettingsImp));

            services.AddTransient(typeof(IValidateUser), typeof(ValidateUserImp));
            


            services.AddScoped(typeof(IUnitOfContext), typeof(UnitOfContextImp));

             
            services.AddDbContext<TempaAuthContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthenticationApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
