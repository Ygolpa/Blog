using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Blog.Application.Contracts.Comment
{

    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int status { get; set; }
        public string CreationDate { get; set; }
        public string Article { get; set; }

    }

}
