using ibmsapi.Data;
using ibmsapi.DTO;
using ibmsapi.Models;

namespace ibmsapi.Services
{
    public class Mutation
    {
        public async Task<Book> AddBook([Service] ApplicationDbContext context, BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook([Service] ApplicationDbContext context, BookDto bookDto)
        {
            var book = await context.Books.FindAsync(bookDto.Id);
            if (book != null)
            {
                book.Title = bookDto.Title;
                book.AuthorId = bookDto.AuthorId;
                await context.SaveChangesAsync();
            }
            return book;
        }
    }
}
