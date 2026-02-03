using Blog.Domain.ArticleAgg;
using Blog.Domain.ArticleCategoryAgg;
using Blog.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.EFCore
{
    public class BlogContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public BlogContext(DbContextOptions<BlogContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
        }
    }
}
