using System.Globalization;
using AvaliacaoCore;
using AvaliacaoCore.DB;
using AvaliacaoWeb.Converters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvaliacaoWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuracao.Inicializar(configuration["App:UF"]);
            var inicializador = new InicializadorBancoDeDados(new ManipuladorSqlite());
            inicializador.Iniciar();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Culture = CultureInfo.GetCultureInfo("pt-BR");
                options.SerializerSettings.Converters.Add(new TelefoneConverter());
            }); ;

            //PLUS: Neste projeto não é utilizado injeção de dependencia. Pode ser implementado. Sujiro que mesmo que não implmente aqui, leia um pouco sobre.
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

        }
    }
}
