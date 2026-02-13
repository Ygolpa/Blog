using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Contracts.Comment
{
    public class AddCommnet
    {
        public string  Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int ArticleId { get; set; }

    }
}
