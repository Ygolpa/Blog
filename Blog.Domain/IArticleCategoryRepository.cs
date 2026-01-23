using Blog.Domain.ArticleCategoryAgg;

namespace Blog.Domain
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Add(ArticleCategory entity);
        ArticleCategory GetById(int id);
        void Save();
        bool DoesExistTitle(string title);
    }
}
