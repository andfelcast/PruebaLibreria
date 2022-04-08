using LibreriaEntities.Entities;
using LibreriaLogica.Implementacion;
using LibreriaLogica.Interfaces;
using LibreriaRepository.Implementacion;
using LibreriaRepository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibreriaAPI
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
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<LibreriaDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbLibreria")));
            services.AddTransient<IAutorLogica, AutorLogica>();
            services.AddTransient<ILibroLogica, LibroLogica>();
            services.AddTransient<IUsuarioLogica, UsuarioLogica>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<ILibroRepository, LibroRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200", "http://www.myclientserver.com")
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
