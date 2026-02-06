namespace Blog.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetAllArticles();
        ArticleQueryView GetArticleById(int id);
    }
}
