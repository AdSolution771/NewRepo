using ibmsapi.Data;
using ibmsapi.Models;
// Resolvers
public class BookResolvers
{
    public Author GetAuthor(Book book, [ScopedService] ApplicationDbContext context)
    {
        var author = context.Authors.FirstOrDefault(a => a.Id == book.AuthorId);
        if (author == null)
        {
            Console.WriteLine($"Author not found for book with ID {book.Id}");
        }
        return author;
    }
}
