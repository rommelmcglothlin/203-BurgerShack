using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Data;
using BurgerShack.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;

namespace BurgerShack
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

<<<<<<< HEAD
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "BurgerShack", Version = "v1" });
      });
      services.AddSingleton<FakeDb>();

      services.AddScoped<IDbConnection>(o => CreateDbConnection());
=======
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BurgerShack", Version = "v1" });
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    //   options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                    //   options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                    options.Events.OnRedirectToLogin = (context) =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });

            services.AddScoped<IDbConnection>(o => CreateDbConnection());

            services.AddTransient<AccountRepository>();
            services.AddTransient<AccountService>();

            services.AddTransient<ItemsRepository>();
            services.AddTransient<ItemsService>();

            services.AddTransient<OrdersRepository>();
            services.AddTransient<OrdersService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
>>>>>>> 617ab6e9eb43efa2092f52584f4aa2681194621c

      services.AddTransient<BurgersRepository>();
      services.AddTransient<BurgersService>();

      services.AddTransient<OrdersRepository>();
      services.AddTransient<OrdersService>();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

<<<<<<< HEAD
    private IDbConnection CreateDbConnection()
    {
      var connectionString = Configuration.GetSection("db").GetValue<string>("gearhost");
=======
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BurgerShack");
            });
>>>>>>> 294f4f4416a9cdf12f3a1b136968e45b5cecc48b

      return new MySqlConnection(connectionString);
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

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BurgerShack");
      });

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
