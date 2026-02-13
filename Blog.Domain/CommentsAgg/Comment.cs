using Blog.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.CommentsAgg
{
    public partial class Comment
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; }  //0-New  1-Confirmed  2-Canceled
        //public Statuses Status { get; private set; }  //I think using enum is better
        public DateTime CreationDate { get; private set; }
        public int ArticleId { get; private set; }
        public Article Article { get; private set; }

        protected Comment()
        {
        }

        public Comment(string name, string email, string message, int articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate = DateTime.Now;
            Status = Statuses.New;
        }

        public void Confirm() => Status = Statuses.Confirmed;
        public void Cancel() => Status = Statuses.Canceled;
       

        
    }
}
