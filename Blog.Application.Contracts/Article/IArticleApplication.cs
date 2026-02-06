using Blog.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAllArticles();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle Get(int id);
        void Delete(int id);
        void Activate(int id);
    }
}
