using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREMyCookBookAPI.Context;
using COREMyCookBookAPI.Models;
using COREMyCookBookAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace COREMyCookBookAPI
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
            services.AddDbContext<MyCookBookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyCookBookContext")));

            services.AddMvc();

            services.AddScoped<IRepository<Recipe>, RecipeRepository>();

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
