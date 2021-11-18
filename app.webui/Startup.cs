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
                    name:"Usersİnfo",
                    pattern:"account/manage/{name}",
                    defaults: new{controller="Account", Action="Manage"}
                );
                 endpoints.MapControllerRoute(
                    name:"DeleteWomanBrands",
                    pattern:"admin/woman/delete/brands/{id?}",
                    defaults: new{controller="Admin", Action="DeleteWomanBrands"}
                );
                 endpoints.MapControllerRoute(
                    name:"DeleteWomanCategory",
                    pattern:"admin/woman/delete/category/{id?}",
                    defaults: new{controller="Admin", Action="DeleteWomanCategory"}
                );
                 endpoints.MapControllerRoute(
                    name:"DeleteWomanProduct",
                    pattern:"admin/woman/delete/product/{id?}",
                    defaults: new{controller="Admin", Action="DeleteWomanProduct"}
                );
                 endpoints.MapControllerRoute(
                    name:"DeleteManBrand",
                    pattern:"admin/man/delete/brands/{id?}",
                    defaults: new{controller="Admin", Action="DeleteManBrands"}
                );
                 endpoints.MapControllerRoute(
                    name:"DeleteManCategory",
                    pattern:"admin/man/delete/product/{id?}",
                    defaults: new{controller="Admin", Action="DeleteManCategory"}
                );
                 endpoints.MapControllerRoute(
                    name:"WomanProductEdit",
                    pattern:"admin/woman/product/edit/{id?}",
                    defaults: new{controller="Admin", Action="WomanProductEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"WomanCategoryEdit",
                    pattern:"admin/woman/categories/edit/{id?}",
                    defaults: new{controller="Admin", Action="WomanCategoryEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"WomansBrandsEdit",
                    pattern:"admin/woman/brands/products/edit/{id}",
                    defaults: new{controller="Admin", Action="WomansBrandsEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"ManBrandsEdit",
                    pattern:"admin/man/brands/products/edit/{id}",
                    defaults: new{controller="Admin", Action="MansBrandsEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"ManCategoryEdit",
                    pattern:"admin/man/categories/edit/{id?}",
                    defaults: new{controller="Admin", Action="ManCategoriesEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"ManProductEdit",
                    pattern:"admin/man/products/edit/{id?}",
                    defaults: new{controller="Admin", Action="ManProductsEdit"}
                );
                 endpoints.MapControllerRoute(
                    name:"CreateWomanBrands",
                    pattern:"admin/woman/brands/create",
                    defaults: new{controller="Admin", Action="CreateWomanBrands"}
                );
                 endpoints.MapControllerRoute(
                    name:"WomanCategoryList",
                    pattern:"admin/woman/category/list",
                    defaults: new{controller="Admin", Action="WomanCategoryList"}
                );
                 endpoints.MapControllerRoute(
                    name:"CreateManBrands",
                    pattern:"admin/man/brands/create",
                    defaults: new{controller="Admin", Action="CreateManBrands"}
                );
                 endpoints.MapControllerRoute(
                    name:"WomanProductsBrands",
                    pattern:"admin/woman/products/brands",
                    defaults: new{controller="Admin", Action="WomanProductsBrands"}
                );
                 endpoints.MapControllerRoute(
                    name:"CreateWomanCategory",
                    pattern:"admin/woman/category/create",
                    defaults: new{controller="Admin", Action="CreateWomanCategory"}
                );
                 endpoints.MapControllerRoute(
                    name:"ManProductsBrands",
                    pattern:"admin/man/products/brands",
                    defaults: new{controller="Admin", Action="ManProductsBrands"}
                );
                 endpoints.MapControllerRoute(
                    name:"CreateManCategory",
                    pattern:"admin/man/category/create",
                    defaults: new{controller="Admin", Action="CreateManCategory"}
                );
                 endpoints.MapControllerRoute(
                    name:"ManProductsCreate",
                    pattern:"admin/man/products/create",
                    defaults: new{controller="Admin", Action="CreateManProduct"}
                );
                 endpoints.MapControllerRoute(
                    name:"WomanProductsCreate",
                    pattern:"admin/woman/products/create",
                    defaults: new{controller="Admin", Action="CreateWomanProducts"}
                );
                 endpoints.MapControllerRoute(
                    name:"WomanProducts",
                    pattern:"admin/woman/products/list",
                    defaults: new{controller="Admin", Action="WomanProducts"}
                );
                 endpoints.MapControllerRoute(
                    name:"ManProducts",
                    pattern:"admin/man/products/list",
                    defaults: new{controller="Admin", Action="ManProducts"}
                );
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
                    pattern:"Admin/man/categories/list",
                    defaults: new{controller="Admin", Action="ManCategoryList"}
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
