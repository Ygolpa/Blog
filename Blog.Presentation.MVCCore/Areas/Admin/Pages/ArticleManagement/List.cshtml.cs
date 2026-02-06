using Blog.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Presentation.MVCCore.Areas.Admin.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles= _articleApplication .GetAllArticles();
        }
        
        public RedirectToPageResult OnPostActivate(int id)
        {
            _articleApplication.Activate(id);
            return RedirectToPage("./list");
        }
        public RedirectToPageResult OnPostDelete(int id)
        {
            _articleApplication.Delete(id);
            return RedirectToPage("./list");
        }
    }
}
