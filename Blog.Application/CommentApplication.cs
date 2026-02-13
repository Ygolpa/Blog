using Blog.Application.Contracts.Comment;
using Blog.Domain.CommentsAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddCommnet command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
        }

        public List<CommentViewModel> GetAllComments()
        {
            return _commentRepository.GetAllComments();
        }

        public void Confirm(int id)
        {
            //following coded by me
            // _commentRepository.GetComment(id).Confirm();
            var comment = _commentRepository.GetComment(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public void Cancel(int id)
        {
            _commentRepository.GetComment(id).Cancel();
            _commentRepository.Save();
        }
    }
}
