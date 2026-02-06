using Blog.Domain.ArticleAgg;
using System.Runtime.InteropServices;

namespace Blog.Application.Contracts.Article
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetAllArticles()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticle command)
        {
            var article = new Blog.Domain.ArticleAgg.Article(command.Title, command.ShortDescription,
                command.Image, command.Content, command.ArticleCategoryId)
            { };
            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public EditArticle Get(int id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public void Delete(int id)
        {
            var article = _articleRepository.Get(id);
            article.Delete();
            _articleRepository.Save();
        }

        public void Activate(int id)
        {
            var article = _articleRepository.Get(id);
            article.Activate();
            _articleRepository.Save();
        }
    }
}
