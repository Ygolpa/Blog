using Blog.Application.Contracts.Comment;
using Blog.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(int id)
        {
            Article = _articleQuery.GetArticleById(id);
        }

        public RedirectToPageResult OnPost(AddCommnet command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails",new {id=command.ArticleId});
        }
    }
}