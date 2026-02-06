using Blog.Application.Contracts.Article;
using Blog.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public List<ArticleViewModel> GetAll()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id=x.Id,
                Title=x.Title,
                ArticleCategory=x.ArticleCategory.Title,
                IsDeleted=x.IsDeleted,
                CreationDate=x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }

        public void Create(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public Article Get(int id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
                    }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
