namespace StoreServices.API.ShoppingCart.Application
{
    public class ShoppingCartDto
    {
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public required List<ShoppingCartDetailsDto> Details { get; set; }
    }
}
