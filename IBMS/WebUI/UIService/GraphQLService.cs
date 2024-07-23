using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using WebUI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

public class GraphQLService
{
    private readonly GraphQLHttpClient _client;

    public GraphQLService()
    {
        var options = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri("https://localhost:7268/graphql") // Adjust the URL as needed
        };
        _client = new GraphQLHttpClient(options, new NewtonsoftJsonSerializer());
    }

    public async Task<List<BookDto>> GetBooksAsync()
    {
        var request = new GraphQLRequest
        {
            Query = @"
            query {
                books {
                    id
                    title
                    author {
                        name
                    }
                }
            }"
        };

        var response = await _client.SendQueryAsync<ResponseType>(request);
        return response.Data.Books;
    }

    public async Task<BookDto> AddBookAsync(BookDto bookDto)
    {
        var request = new GraphQLRequest
        {
            Query = @"
            mutation($title: String!, $authorId: Int!) {
                addBook(bookDto: {title: $title, authorId: $authorId}) {
                    id
                    title
                    author {
                        name
                    }
                }
            }",
            Variables = new { title = bookDto.Title, authorId = bookDto.AuthorId }
        };

        var response = await _client.SendMutationAsync<ResponseType>(request);
        return response.Data.AddBook;
    }
}

// Response types
public class ResponseType
{
    public List<BookDto> Books { get; set; }
    public BookDto AddBook { get; set; }
}
