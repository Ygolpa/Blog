using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetAllComments();
        void Add(AddCommnet command);
        void Confirm(int id);
        void Cancel(int id);
    }
}
