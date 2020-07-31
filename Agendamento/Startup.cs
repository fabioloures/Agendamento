using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.reposit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace Agendamento
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

            //add
            services.AddDbContext<SalaContext>(options => {
                //var connectionString = @"Password=master;Persist Security Info=True;User ID=sa;Initial Catalog=AgendamentoApp;Data Source=DESKTOP-C54G0EB\SQLEXPRESS";
                
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConcection"));
                //options.UseSqlServer(@connectionString);
            });

            //ConfigureServices ADD ERRO DE POST
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .WithHeaders(HeaderNames.ContentType, "application/json")
                                      .WithMethods("PUT", "DELETE", "GET", "OPTIONS", "POST")
                    );
            });

            services.AddCors(); // ADD Make sure you call this previous to AddMvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors( // ADD
        options => options.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseHttpsRedirection();



            //app.UseCors(
            //options => options.WithOrigins("http://localhost:4200", "https://localhost:4200")
            //                .AllowAnyHeader().AllowAnyMethod().AllowCredentials()
            //            );
            //FIM Configure ADD



            app.UseMvc();





        }








    }
}
