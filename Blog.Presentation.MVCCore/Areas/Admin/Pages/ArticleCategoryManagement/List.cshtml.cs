using Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Presentation.MVCCore.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryAjpplication;
        public ListModel(IArticleCategoryApplication articleCategoryAjpplication)
        {
            _articleCategoryAjpplication = articleCategoryAjpplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryAjpplication.GetAllCategories();
        }

        public RedirectToPageResult OnPostDelete(int id)
        {
            _articleCategoryAjpplication.Delete(id);
            return RedirectToPage("GetAllCategories");
        }
        public RedirectToPageResult OnPostActivate(int id)
        {
            _articleCategoryAjpplication.Activate(id);
            return RedirectToPage("GetAllCategories");
        }
    }
}
