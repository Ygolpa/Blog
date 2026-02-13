using Blog.Application.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.CommentsAgg
{
    public interface ICommentRepository
    {
        List<CommentViewModel> GetAllComments();
        void Create(Comment entity);
        Comment GetComment(int id);
       
        void Save();
    }
}
