using BooksPF.Core;
using BooksPF.Core.Abstract;
using BooksPF.Core.Mongo;
using BooksPF.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace BooksPF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var authOptions = Configuration.GetSection("Auth");
            services.Configure<BooksPFDbConfig>(Configuration);
            services.Configure<AuthOptions>(authOptions);
            services.AddSingleton<IDbClient, DbClient>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IUserService, UserService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BooksPF", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksPF v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
