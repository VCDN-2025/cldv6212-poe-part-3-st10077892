namespace ABC_RETAIL_MVC
{
    using ABC_RETAIL_MVC.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Add this using
    using Microsoft.AspNetCore.Builder; // Add this using

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddSession();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            var app = builder.Build();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

//Name: CLDV6212 Azure functions part 1 Getting the basics out the way HTTP Trigger
//Author: IIE Emeris School of Computer Science
//Url: https://youtu.be/l7s5u-QzYe8?si=UKfsznYR12jxdEa9
//Date accessed: 12 November 2025

//Name: CLDV6212 Azure functions part 2 Azure functions and queues triggers
//Author:IIE Emeris School of Computer Science
//Url: https://youtu.be/zP4umzRCsTM?si=-gG6a3p06R7kQtHy
//Date accessed: 12 November 2025

//Name: CLDV6212 Azure functions part 3 Azure functions and MVC
//Author: IIE Emeris School of Computer Science
//Url: https://youtu.be/x7yTh85fQbw?si=YVjxUyzChioyR2jb
//Date accessed: 12 November 2025

//Name: CLDV6212 Azure functions part 4 Azure functions and MVC and blobs
//Author:IIE Emeris School of Computer Science
//Url: https://youtu.be/r-VksPFfFpE?si=YBzXZTbKv4wVDbT8
//Date accessed: 12 November 2025

//Name: CLDV6212 Azure functions part 5 Azure functions publish
//Author: IIE Emeris School of Computer Science
//Url: https://youtu.be/GXGN-aWbwO0?si=OQcVvKZUEsLoIDtL
//Date accessed: 12 November 2025

//Name: Introduction to Identity on ASP.NET Core
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-10.0&tabs=visual-studio
//Date accessed: 12 November 2025

//Name: Get started with ASP.NET Core MVC
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-10.0&tabs=visual-studio
//Date accessed: 12 November 2025

//Name: Configure ASP.NET Core session state
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-10.0&tabs=windows#session-state
//Date accessed: 12 November 2025

//Name: Map static assets in ASP.NET Core
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-10.0#map-static-assets
//Date accessed: 12 November 2025

//Name: Entity Framework Core with ASP.NET Core Identity
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-entity-framework-core?view=aspnetcore-10.0&tabs=visual-studio
//Date accessed: 12 November 2025

//Name: ASP.NET Core Identity configuration options
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration-options?view=aspnetcore-10.0&tabs=visual-studio
//Date accessed: 12 November 2025

//Name: Introduction to ASP.NET Core
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-10.0&tabs=visual-studio
//Date accessed: 12 November 2025

//Name: ASP.NET Core fundamentals
//Author: Microsoft
//Url: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-10.0&tabs=windows
//Date accessed: 12 November 2025

//Name: Cloud Solution Analysis
//Author: ChatGPT-4
//Url: https://chatgpt.com/share/69187163-dba8-8006-823a-869d76b8392d
//Date accessed: 12 November 2025