using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.Extensions.Options;
using Echo.Interfaces;
using Echo.Services;

namespace Echo
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<IExhibitRepository, ExhibitJson>();
            services.AddTransient<IArticleRepository, ArticleJson>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("da"),
                    new CultureInfo("en")
                };
                options.DefaultRequestCulture = new RequestCulture("da-DA");
                options.SupportedCultures= supportedCultures;
                options.SupportedUICultures= supportedCultures;
            });
            services.AddMvc().AddViewLocalization();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;

            app.UseRequestLocalization(localizationOptions);

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
