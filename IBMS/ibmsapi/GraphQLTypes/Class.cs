using HotChocolate.Types;
using ibmsapi.Data;
using ibmsapi.Models;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(b => b.Id).Type<NonNullType<IdType>>();
        descriptor.Field(b => b.Title).Type<NonNullType<StringType>>();
        descriptor.Field(b => b.Author).Type<AuthorType>().ResolveWith<BookResolvers>(b => b.GetAuthor(default!, default!));
    }
}

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.Field(a => a.Id).Type<NonNullType<IdType>>();
        descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Books).Type<ListType<BookType>>().ResolveWith<AuthorResolvers>(a => a.GetBooks(default!, default!));
    }
}

// Resolvers
public class BookResolvers
{
    public Author GetAuthor(Book book, [ScopedService] ApplicationDbContext context)
    {
        return context.Authors.Find(book.AuthorId);
    }
}

public class AuthorResolvers
{
    public IEnumerable<Book> GetBooks(Author author, [ScopedService] ApplicationDbContext context)
    {
        return context.Books.Where(b => b.AuthorId == author.Id);
    }
}
