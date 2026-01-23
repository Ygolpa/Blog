using Blog.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
//برای جلوگیری از دسترسی لایه یو آی به لایه های داخلی این کدها به لایه دیگر منتقل شدن
//و بجاش کد پایین رو زدیم
//builder.Services.AddDbContext<BlogContext>(option =>
//option.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB")));
//builder.Services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
//builder.Services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
string? connectionString = builder.Configuration.GetConnectionString("BlogDB");
Bootstrapper.Config(builder.Services, connectionString);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
