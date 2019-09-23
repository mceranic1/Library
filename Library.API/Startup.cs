using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace Library.API
{
    public class Startup  // ovdje se radi kompletna konfiguracija
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented);  // da bi ljepse izgledalo na browseru

            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ContractResolver = new DefaultContractResolver {  // atributi su pisani po camelcase konvenciji
                NamingStrategy = new CamelCaseNamingStrategy()
            });

            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects);  // da imamo pristup svim knjigama pri ispisu


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
