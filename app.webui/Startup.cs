using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using app.business.Abstract;
using app.business.Concrete;
using app.data.Abstract;
using app.data.Concrete.EfCore;
using app.webui.EmailServices;
using app.webui.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace app.webui
{
    public class Startup
    {
       private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options=> options.UseSqlite("Data Source=appDb"));
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options=> {
                // password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options=> {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>(); 
            services.AddScoped<IProductRepository,EfCoreProductRepository>(); 
            services.AddScoped<ICartRepository,EfCoreCartRepository>();
     

            services.AddScoped<IProductService,ProductManager>(); 
            services.AddScoped<ICategoryService,CategoryManager>(); 
            services.AddScoped<ICartService,CartManager>();


            services.AddScoped<IEmailSender,SmtpEmailSender>(i=> 
                new SmtpEmailSender(
                    _configuration["EmailSender:Host"],
                    _configuration.GetValue<int>("EmailSender:Port"),
                    _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    _configuration["EmailSender:UserName"],
                    _configuration["EmailSender:Password"])
                );

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); // wwwroot

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                    RequestPath="/modules"                
            });
            
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                
                
                
                 endpoints.MapControllerRoute(
                    name:"Comments",
                    pattern:"shop/comment",
                    defaults: new{controller="Shop", Action="Comment"}
                );
                 endpoints.MapControllerRoute(
                    name:"Cart",
                    pattern:"cart/ındex",
                    defaults: new{controller="Cart", Action="Index"}
                );
                 endpoints.MapControllerRoute(
                    name:"edit",
                    pattern:"admin/user/{id?}",
                    defaults: new{controller="Admin", Action="UserEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"list",
                    pattern:"admin/users/list",
                    defaults: new{controller="Admin", Action="UserList"}
                );
                 endpoints.MapControllerRoute(
                    name:"Role",
                    pattern:"Admin/Roles",
                    defaults: new{controller="Admin", Action="RoleList"}
                );
                 endpoints.MapControllerRoute(
                    name:"Roleedit",
                    pattern:"Admin/Roles/{id?}",
                    defaults: new{controller="Admin", Action="RoleEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"Role",
                    pattern:"Admin/Role/Create",
                    defaults: new{controller="Admin", Action="CreateRole"}
                ); 
                 endpoints.MapControllerRoute(
                    name:"Categorylist",
                    pattern:"Admin/categories",
                    defaults: new{controller="Admin", Action="CategoryList"}
                ); 
                 endpoints.MapControllerRoute(
                    name:"Categoryedit",
                    pattern:"Admin/categories/{id?}",
                    defaults: new{controller="Admin", Action="CategoryEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"Categorycreate",
                    pattern:"Admin/category/create",
                    defaults: new{controller="Admin", Action="CategoryCreate"}
                ); 
                endpoints.MapControllerRoute(
                    name:"Createproduct",
                    pattern:"Admin/products/create",
                    defaults: new{controller="Admin", Action="CreateProduct"}
                ); 
                 endpoints.MapControllerRoute(
                    name:"Products",
                    pattern:"Admin/products",
                    defaults: new{controller="Admin", Action="Products"}
                ); 
                 endpoints.MapControllerRoute(
                    name:"ProductEdit",
                    pattern:"Admin/products/{id?}",
                    defaults: new{controller="Admin", Action="ProductEdit"}
                ); 
                
               
                endpoints.MapControllerRoute(
                    name:"Acending",
                    pattern:"Shop/Acending",
                    defaults: new{controller="Shop", Action="Acending"}
                );    

                 endpoints.MapControllerRoute(
                    name:"decending",
                    pattern:"Shop/Decending",
                    defaults: new{controller="Shop", Action="Decending"}
                );      
                endpoints.MapControllerRoute(
                    name:"shopmanbodies",
                    pattern:"shop/man/bodies/{url?}",
                    defaults: new{controller="Shop", Action="ManBodies"}
                );  
                endpoints.MapControllerRoute(
                    name:"shopmanbrandsdetails",
                    pattern:"shop/man/brands/{url?}",
                    defaults: new{controller="Shop", Action="ManBrandDetails"}
                );
                endpoints.MapControllerRoute(
                    name:"shopmancategoriesurl",
                    pattern:"shop/man/categories/{url?}",
                    defaults: new{controller="Shop", Action="ManCategories"}
                );
                endpoints.MapControllerRoute(
                    name:"shopmanlist",
                    pattern:"shop/man/list",
                    defaults: new{controller="Shop", Action="Man"}
                );
                endpoints.MapControllerRoute(
                    name:"productdetails",
                    pattern:"products/{url}/{id?}",
                    defaults: new{controller="Shop", Action="Details"}
                ); 
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
