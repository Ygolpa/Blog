using Blog.Application.Contracts.ArticleCategory;
using Blog.Domain;
using Blog.Domain.ArticleCategoryAgg;
using Blog.Domain.ArticleCategoryAgg.Services;
using System.Runtime.CompilerServices;

namespace Blog.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public List<ArticleCategoryViewModel> List()
        {
            //Dirty code, Later is get cleaned
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel()
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString()
                });
            }
            return result;
        }

        public void Create(CreateArticleCategory command)
        {
            //var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            var articleCategory = new ArticleCategory(command.Title);
            _articleCategoryRepository.Add(articleCategory);
        }

        public void Edit(EditArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.GetById(command.Id);
            articleCategory.Edit(command.Title);
            _articleCategoryRepository.Save();
        }

        //برای اینکه در پیچ ادیت بتوان کتگوری را گرفت
        public EditArticleCategory GetById(int id)
        {
            var articleCategory =_articleCategoryRepository.GetById(id);
            return new EditArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };
        }

        public void Delete(int id)
        {
            var articleCategory=_articleCategoryRepository.GetById(id);
            articleCategory.Delete();
            _articleCategoryRepository.Save();
        }

        public void Activate(int id)
        {
            var articleCategory= _articleCategoryRepository.GetById(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }
    }
}
