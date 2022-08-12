using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace WebServicesBiblioteca
{
    public  class Startup
    {
        public object Configuration { get; set; }
        readonly static string Micors = "Micors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
       
        public void ConfiguracionServicio(IServiceCollection service)
        {
            service.AddCors(option =>
            {
                option.AddPolicy(name: Micors,
                                    builder =>
                                    {
                                        builder.WithOrigins("*");
                                    }
                                    );
            }
            );
        }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
        private static void Configure(WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(Micors);
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
