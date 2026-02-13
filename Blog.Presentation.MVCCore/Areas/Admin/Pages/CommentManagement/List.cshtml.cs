using Blog.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Presentation.MVCCore.Areas.Admin.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public List<CommentViewModel> Comments { get; set; }

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
            
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetAllComments();
        }

        
        public RedirectToPageResult OnPostConfirm(int id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostCancel(int id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./List");
        }
    }
}
