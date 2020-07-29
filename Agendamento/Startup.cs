﻿using System;
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
