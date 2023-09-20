namespace StoreServices.API.ShoppingCart.Application
{
    public class ShoppingCartDetailsDto
    {
        public Guid BookId {  get; set; }
        public required string Title { get; set; }
        public required Guid Author { get; set; }
        public DateTime? PublishDate { get; set; }

    }
}
