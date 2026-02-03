using Blog.Domain.ArticleAgg;
using Blog.Domain.ArticleCategoryAgg.Services;

namespace Blog.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        //وقتی این کانستراکتور نبود چون ورودی دوم کانستراکتور پایینی نمی توست بایند بشه
        //ارور میداد و کانستراکتور اصلی رو فقط بخاطر اینکه ای اف ارور نده ساختیم
        private ArticleCategory() { } 
        public ArticleCategory(string title,IArticleCategoryValidatorService validatorService)
        //public ArticleCategory(string title)
        {
            GaurdAgainstEmptyTitle(title);
            validatorService.DoesExistTitle(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
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
