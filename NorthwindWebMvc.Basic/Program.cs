using Microsoft.EntityFrameworkCore;
using NorthwindWebMvc.Basic.Mapping;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Models.Dto;
using NorthwindWebMvc.Basic.Repository;
using NorthwindWebMvc.Basic.RepositoryContext;
using NorthwindWebMvc.Basic.Services;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

		// Register AutoMapper
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        // Register interface and interface implementations
        builder.Services.AddScoped<IRepositoryBase<Category>, CategoryRepository>();
		builder.Services.AddScoped<ICategoryService<CategoryDto>, CategoryService>();

		// register dbcontext to services 
		builder.Services.AddDbContext<RepositoryDbContext>(options =>		
			options.UseSqlServer(builder.Configuration.GetConnectionString("ShopeeConnection")));

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}