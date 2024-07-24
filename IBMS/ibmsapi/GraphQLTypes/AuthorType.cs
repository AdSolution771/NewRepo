using HotChocolate.Types;
using ibmsapi.Models;

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.Field(a => a.Id).Type<NonNullType<IdType>>();
        descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Books).Type<ListType<BookType>>().ResolveWith<AuthorResolvers>(a => a.GetBooks(default!, default!));
    }
}
