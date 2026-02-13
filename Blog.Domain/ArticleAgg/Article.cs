using Blog.Domain.ArticleCategoryAgg;
using Blog.Domain.CommentsAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.ArticleAgg
{
    public class Article
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        //بخاطر اینکه ای اف کور نیاز به یک کانستراکتور خالی دارد
        //پراتکتد بخاطر اینکه کسی نتواند مستقیما آرتیکل رو نیو بکند
        protected Article() { }

        public Article(string title, string shortDescription, string image, string content, int articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Comments=new List<Comment>();
        }

        public void Edit(string title, string shortDescription, string image, string content, int articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
