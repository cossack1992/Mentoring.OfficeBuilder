using Blazor.FileReader;
using Ganss.XSS;
using Mentoring.OfficeBuilder.Services.UploadFile;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Mentoring.OfficeBuilder
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);

            services.AddSingleton<IUploadService, UploadService>();

            services.AddScoped<IHtmlSanitizer, HtmlSanitizer>(x =>
            {
                var sanitizer = new HtmlSanitizer();
                return sanitizer;
            });

        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
