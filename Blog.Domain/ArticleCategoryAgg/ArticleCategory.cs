using Blog.Domain.ArticleCategoryAgg.Services;

namespace Blog.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        //public ArticleCategory(string title,IArticleCategoryValidatorService validatorService)
        public ArticleCategory(string title)
        {
            //validatorService.DoesExistTitle(title);
            GaurdAgainstEmptyTitle(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }
        public void Edit(string title)
        {
            GaurdAgainstEmptyTitle(title);
            Title = title;
        }
        public void Delete()
        {
            IsDeleted=true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }
        public void GaurdAgainstEmptyTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

    }
}
