using Blog.Domain.ArticleCategoryAgg.Exceptions;

namespace Blog.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void DoesExistTitle(string title)
        {
            if (_articleCategoryRepository.DoesExistTitle(title))
                //اکسپشن اختصاصی
                throw new DuplicateRecordException("This recored already exists.");
        }
    }
}
