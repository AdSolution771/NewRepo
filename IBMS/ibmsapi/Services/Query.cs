using ibmsapi.Data;
using ibmsapi.Models;

namespace ibmsapi.Services
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Book> GetBooks([ScopedService] ApplicationDbContext context)
        {
            return context.Books;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Author> GetAuthors([ScopedService] ApplicationDbContext context)
        {
            return context.Authors;
        }
    }
}
