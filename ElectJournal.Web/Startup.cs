using ElectJournal.Core.Interfaces;
using ElectJournal.Infrastrusture;
using ElectJournal.Infrastrusture.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectJournal.Core.Services;
using ElectJournal.Web.Services;
using ElectJournal.Web.Interfaces;
using ElectJournal.Infrastrusture.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using ElectJournal.Infrastrusture.Services;

namespace ElectJournal.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<JournalDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("Journal")));
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubjService, SubjService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<ILessonsService, LessonService>();
            services.AddScoped<IUserViewModelService, UserViewModelService>();
            services.AddScoped<ILessonsViewModelService, LessonsViewModelService>();
            services.AddScoped<ISubjViewModelService, SubjViewModelService>();
            services.AddScoped<IGroupViewModelService, GroupViewModelService>();
            services.AddScoped<IUserDeleteViewModelService, UserDeleteViewModelService>();
            services.AddScoped<ITimetableService, TimetableService>();
            services.AddScoped<ITimetableViewModelService, TimetableViewModelService>();
            services.AddScoped<IMarkViewModelService, MarkViewModelService>();

            //services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<ITimeService>(provider => new TestTimeService(new DateTime(2022, 1, 28, 12, 30, 30)));


            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/User/SignIn");
                    options.AccessDeniedPath = new PathString("/User/SignIn");
                });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Registration}");
            });
        }
    }
}
