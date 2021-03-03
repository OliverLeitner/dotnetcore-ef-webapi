using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

// dbcontext usemysql
using Microsoft.EntityFrameworkCore;

// compression
using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace DotNetCoreSampleApi
{
    public class Startup
    {
        public static string dbConnectionString = ""; // for now...

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // for handling within the app
            dbConnectionString = Configuration.GetConnectionString("DefaultConnection");

            // https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-5.0
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(Configuration.GetValue<string>("CorsList"));
                    });
            });

            // Configure Compression level
            services.Configure<GzipCompressionProviderOptions>(options => 
                options.Level = CompressionLevel.Optimal
            );

            services.Configure<BrotliCompressionProviderOptions>(options =>
                options.Level = CompressionLevel.Optimal
            );

            // Add Response compression services
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ); // we go here
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetCoreSampleApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // dev only thing, i really dont need this
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetCoreSampleApi v1"));
            }*/

            // app.UseHttpsRedirection(); // in production...

            app.UseResponseCompression();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
