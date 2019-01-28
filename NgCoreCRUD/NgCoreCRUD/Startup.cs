﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NgCoreCRUD.DAL;
using NgCoreCRUD.Model.Services;

namespace NgCoreCRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<GalleryDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("GalleryDB"), options => options.CommandTimeout(120)));

            services.Add(new ServiceDescriptor(typeof(IGalleryService), typeof(GalleryService), ServiceLifetime.Transient));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Frontend/gallery-front/dist";
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(builder => 
            {
                builder.Options.SourcePath = "Frontend/gallery-front";


                if (env.IsDevelopment())
                {
                    builder.UseAngularCliServer(npmScript: "start");
                }

            });
        }
    }
}
