using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoPortfolio.Business.Builder.CryptoPortfolio;
using CryptoPortfolio.Business.Builder.Interfaces.CryptoPortfolio;
using CryptoPortfolio.Business.Builder.Mapping;
using CryptoPortfolio.Business.Entities.Crypto;
using CryptoPortfolio.Business.Manager;
using CryptoPortfolio.Business.Service;
using CryptoPortfolio.Data;
using CryptoPortfolio.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CryptoPortfolio.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Mappings.RegisterMappings();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.connectionString
                    = Configuration.GetSection("MongoDbConnection:ConnectionString").Value;
                options.database
                    = Configuration.GetSection("MongoDbConnection:Database").Value;
            });

            services.AddMvc();

            services.AddScoped<IApiInformationRepository, ApiInformationRepository>();
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddTransient<IBalanceRepository, BalanceRepository>();
            services.AddTransient<ICryptoValueRepository, CryptoValueRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IApiInformationBuilder, ApiInformationBuilder>();
            services.AddTransient<ICryptoPortfolioService, CryptoPortfolioManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "CrytpoBits API",
                    Description = "RESTful API endpoints for CryptoBits",
                    Contact = new Contact { Name = "CryptoBitfolio", Email = "CryptoBitfolio@gmail.com", Url = "https://twitter.com/CryptoBitfolio" },
                    Version = "1.0"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoBits API V1");
            });

            app.UseMvc();
        }
    }
}
