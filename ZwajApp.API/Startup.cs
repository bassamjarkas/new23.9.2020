﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZwajApp.API.Data;
using ZwajApp.API.Helpers;
using ZwajApp.API.Model;

namespace ZwajApp.API
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
            services.AddCors();
            services.AddAutoMapper();
            services.AddDbContext<dbcontext>(x => x.UseSqlite(Configuration.GetConnectionString("connect")));
            services.AddScoped<IAuthRepository, Authrepository>();
            services.AddScoped<IZwajrepositpry, ZwajRepository>();
            services.AddTransient<trailData>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(
                x => { x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; }
            );
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters
                {
                  

                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:token").Value)),
                     ValidateIssuerSigningKey = true,
                  
                    ValidateIssuer = false,
                    ValidateAudience = false

                };

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, trailData trail)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(BuilderExtensions =>
                {
                    BuilderExtensions.Run(async context =>
                    {
                    //context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.ExtenionError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }

                    }
                    );

                });
            }

            app.UseHttpsRedirection();

            app.UseCors(Options => Options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            //trail.trial();
            app.UseMvc();
        }
    }
}
