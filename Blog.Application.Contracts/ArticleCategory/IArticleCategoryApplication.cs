namespace Blog.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        EditArticleCategory GetById(int id);
        void Delete(int id);
        void Activate(int id);
    }
}
