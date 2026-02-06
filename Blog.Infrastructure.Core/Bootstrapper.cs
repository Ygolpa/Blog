using Blog.Application;
using Blog.Application.Contracts.Article;
using Blog.Application.Contracts.ArticleCategory;
using Blog.Domain.ArticleAgg;
using Blog.Domain.ArticleCategoryAgg;
using Blog.Domain.ArticleCategoryAgg.Services;
using Blog.Infrastructure.EFCore;
using Blog.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<BlogContext>(option =>
            option.UseSqlServer(connectionString, b => b.MigrationsAssembly("Blog.Infrastructure.EFCore")));

            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
        
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

        
        
        }
    }
}
