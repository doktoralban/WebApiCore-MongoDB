using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore_MongoDB.Models;
using WebApiCore_MongoDB.Services;

namespace WebApiCore_MongoDB
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
            #region" -   serviceS "
            services.Configure<MongoDBMyDataBaseSettings>(
                Configuration.GetSection(nameof(MongoDBMyDataBaseSettings)));

            services.AddSingleton<IStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDBMyDataBaseSettings>>().Value);

            services.AddSingleton<ProductService>();
            services.AddSingleton<OrderService>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiCore_MongoDB", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //TODO: a?a??daki sat?r loacalhost tan di?er bir programdam bu servisin ?a?r?lmas?n? sa?l?yor. yoksa client taraf? *cors* hatas? veriyor.
            app.UseCors(builder => builder.AllowAnyOrigin());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiCore_MongoDB v1"));
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
