using Blog.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context)
        {
            _context = context;
        }

    }
}
