using Blog.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Presentation.MVCCore.Areas.Admin.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(int id)
        {
            ArticleCategory = _articleCategoryApplication.GetById(id);
        }
        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Edit(ArticleCategory);
            return RedirectToPage("List");
        }
    }
}
