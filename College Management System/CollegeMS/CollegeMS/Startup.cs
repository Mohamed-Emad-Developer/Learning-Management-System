using CollegeMS.Data;
using CollegeMS.Models;
using CollegeMS.Services;
using CollegeMS.Services.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeMS
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
            services.AddControllersWithViews();

            //for configure our database context---------------------
            services.AddDbContext<CollegeDB>(options =>
                //using Configuration.GetConnectionString("con") to make easier to edit connection string in appsettings.json
                options.UseSqlServer(Configuration.GetConnectionString("con"))
            );

            //for configure Idenity to users for login and registeration
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<CollegeDB>().AddDefaultTokenProviders();
            
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            services.AddScoped<IApplicationUserRepository,ApplicationUserRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                #region route for assign student to course
                endpoints.MapControllerRoute(
                    name: "StudentCoursesRoute",
                    pattern: "{controller=StudentCourses}/{action=Drop}/{studentId}/{courseId}");
                #endregion

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
