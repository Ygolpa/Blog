using Blog.Domain.ArticleCategoryAgg;

namespace Blog.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly BlogContext _context;

        public ArticleCategoryRepository(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }

        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public ArticleCategory GetById(int id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool DoesExistTitle(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }
    }
}
