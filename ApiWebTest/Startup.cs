using HackerNews;
using HackerNews.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ApiWebTest
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IHackerNewsClient, HackerNewsClient>();

            string url = Configuration.GetValue<string>("APISettings:URL");

            string pathTop = Configuration.GetValue<string>("APISettings:PathTop");

            string pathDetails = Configuration.GetValue<string>("APISettings:PathDetails");

            int order =  Configuration.GetValue<int>("APISettings:Order");

            services.AddSingleton<IHackerNewsClient>(new HackerNewsClient(url, pathTop, pathDetails, order));

            // Swagger Config Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Senior Backend Developer Coding Test",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Fernando Maldonado",
                            Email = "fernandomal@hotmail.com",
                            Url = new System.Uri("https://github.com/fernandomal")
                        }
                    });

                string caminhoAplicacao = System.IO.Directory.GetCurrentDirectory(); 
                c.IncludeXmlComments(Path.Combine(caminhoAplicacao, "ApiWebTest.xml"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exemplo de API REST");
            });
        }
    }
}
