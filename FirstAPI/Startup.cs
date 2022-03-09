using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FirstAPI
{
    public class Startup
    {
        public const string AllowAllCorsPolicy = "allowAll";
        public const string AllowOnlyGetCorsPolicy = "allowOnlyGet";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "First API",
                    Version = "v1",
                    Description = "Test Rest service",
                    Contact = new OpenApiContact
                    {
                        Name = "Morten Vestergaard",
                        Email = "move@zealand.dk",
                        Url = new Uri("https://www.zealand.dk"),
                    }
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "First API v2",
                    Version = "v2",
                    Description = "Test Rest service anden version",
                    Contact = new OpenApiContact
                    {
                        Name = "Morten Vestergaard",
                        Email = "move@zealand.dk",
                        Url = new Uri("https://www.zealand.dk"),
                    }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            services.AddCors(options => {
                options.AddPolicy(AllowAllCorsPolicy, policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                options.AddPolicy(AllowOnlyGetCorsPolicy, policy => policy.WithOrigins("https://zealand.dk").WithMethods("GET", "OPTIONS").AllowAnyHeader());
            }
            );

            services.AddDbContext<BookDbContext>(opt => opt.UseSqlServer(Secrets.ConnectionsString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Swagger v2");
            }
            );

            app.UseRouting();

            app.UseCors(AllowOnlyGetCorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
