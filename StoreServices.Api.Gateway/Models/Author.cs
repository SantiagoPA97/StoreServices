namespace StoreServices.API.Gateway.Models
{
    public class Author
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
