using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;
using WebApp.Data;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            //Components or controllers decorated with[Authorize(Policy = "AdminOnly")] will only allow access to users meeting that requirement

            //need sql
     //       INSERT INTO[dbo].[AspNetUserClaims]
     //       ([UserId]
     //      , [ClaimType]
     //      , [ClaimValue])
     //VALUES
     //      ('21db1cce-9b77-47bc-bb75-8bf2512a0bba'
     //      , 'Position'
     //      , 'Admin') or 'Cashier'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
            });

            //Dependency Injection for In-Memory Data Store
            //services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
            //services.AddScoped<IProductRepository, ProductInMemoryRepository>();
            //services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

            //Dependency Injection for ef core Data Store for SQL
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            //Dependency Injection for Use Cases and Repositories
            services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
            services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
            services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            services.AddTransient<IEditProductUseCase, EditProductUseCase>();
            services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IViewProductsByCategoryId, ViewProductsByCategoryId>();
            services.AddTransient<ISellProductUseCase, SellProductUseCase>();
            services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
            services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
            services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //add for identity
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //add for loginDisplay in shared folder
                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
