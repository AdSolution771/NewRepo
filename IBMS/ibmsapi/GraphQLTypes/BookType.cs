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
