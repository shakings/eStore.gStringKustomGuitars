using gStringKustomGuitars.Api.Controllers.Base;
using gStringKustomGuitars.Api.Data;
using gStringKustomGuitars.Api.Data.Abstractions;
using gStringKustomGuitars.Api.Domain.Categories.Builders.Abstractions;
using gStringKustomGuitars.Api.Domain.Categories.Models.Entities;
using gStringKustomGuitars.Api.Domain.Categories.Services;
using gStringKustomGuitars.Api.Domain.Categories.Services.Abstractions;
using gStringKustomGuitars.Api.Domain.Products.Builders;
using gStringKustomGuitars.Api.Domain.Products.Builders.Abstractions;
using gStringKustomGuitars.Api.Domain.Products.Models.Entities;
using gStringKustomGuitars.Api.Domain.Products.Services;
using gStringKustomGuitars.Api.Domain.Products.Services.Abstractions;
using gStringKustomGuitars.Api.Domain.Users.Builders;
using gStringKustomGuitars.Api.Domain.Users.Builders.Abstractions;
using gStringKustomGuitars.Api.Domain.Users.Models.Entities;
using gStringKustomGuitars.Api.Domain.Users.Services;
using gStringKustomGuitars.Api.Domain.Users.Services.Abstractions;
using gStringKustomGuitars.Api.Middleware.ResponseHandeling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace gStringKustomGuitars.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string _connectionString;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gStringKustomGuitars.Api", Version = "v1" });
            });

            _connectionString = Configuration.GetConnectionString("ConnectionString");
            var aptConnection = new AptConnection();
            aptConnection.SetString(_connectionString);
            services.AddScoped<IAptConnection>(serviceProvider => aptConnection);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IExecute, MssqlExecute>();

            services.AddScoped<ICategoryBuilder, CategoryBuilder>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IQuery<PS_CATEGORIES_Results>, MssqlQuery<PS_CATEGORIES_Results>>();

            services.AddScoped<ILoginBuilder, LoginBuilder>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IQuery<PS_LOGIN_Results>, MssqlQuery<PS_LOGIN_Results>>();

            services.AddScoped<IUserBuilder, UserBuilder>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuery<PS_LOGIN_Results>, MssqlQuery<PS_LOGIN_Results>>();

            services.AddScoped<IProductBuilder, ProductBuilder>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IQuery<PS_PRODUCTS_Results>, MssqlQuery<PS_PRODUCTS_Results>>();
}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware(typeof(ErrorWrappingMiddleware));

            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "gStringKustomGuitars.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
