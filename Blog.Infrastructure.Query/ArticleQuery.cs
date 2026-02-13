using Blog.Domain.CommentsAgg;
using Blog.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Blog.Domain.CommentsAgg.Comment;

namespace Blog.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;

        public ArticleQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetAllArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    CommentCount = x.Comments.Count(c => c.Status == Statuses.Confirmed)
                }).ToList();
        }

        public ArticleQueryView GetArticleById(int id)
        {
            return _context.Articles.Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Image = x.Image,
                    Content = x.Content,
                    CommentCount = x.Comments.Count(c => c.Status == Statuses.Confirmed),
                    Comments = MapComments(x.Comments.Where(x=>x.Status==Statuses.Confirmed))
                }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            //var result = new List<CommentQueryView>();
            //foreach (var comment in comments)
            //{
            //    result.Add(new CommentQueryView
            //    {
            //        Name = comment.Name,
            //        Message = comment.Message,
            //        CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture)
            //    });
            //}
            //return result;
            return comments.Select(x => new CommentQueryView
            {
                Name = x.Name,
                Message = x.Message,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            }).ToList();
        }
    }
}
