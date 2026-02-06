using Blog.Application.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetAll();
        void Create(Article entity);
        Article Get(int id);
        void Save();
    }
}
