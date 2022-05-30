using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Repository;
using Login.Data;

namespace Login
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<Controllers.LoginController.Audience>(Configuration.GetSection("Audience"));
            services.AddSwaggerGen();
            services.AddSwaggerGen(
                c => {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "v1",
                        Title = "My API",
                        Description = "Asp.net core web api example"

                    });
                });
            services.AddDbContext<LoginDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LoginConString")));
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(
                c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
                    c.RoutePrefix = string.Empty;
                });
            app.UseMvc();
            
        }
    }
}
