using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArticleCategory { get; set; } //فقط به تایتل آرتیکل کتگوری نیاز داریم
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; } //جهت نمایش در صفحه
    }
}
