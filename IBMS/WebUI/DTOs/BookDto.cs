namespace WebUI.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }  // Add this line
        public AuthorDto Author { get; set; }
    }

    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}