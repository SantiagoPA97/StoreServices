namespace StoreServices.API.Author.Application
{
    public class AuthorDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
