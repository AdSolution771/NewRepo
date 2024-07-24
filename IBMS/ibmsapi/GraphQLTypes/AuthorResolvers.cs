using ibmsapi.Data;
using ibmsapi.Models;

public class AuthorResolvers
{
    public IEnumerable<Book> GetBooks(Author author, [ScopedService] ApplicationDbContext context)
    {
        return context.Books.Where(b => b.AuthorId == author.Id);
    }
}
