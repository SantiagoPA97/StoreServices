namespace StoreServices.API.ShoppingCart.Models
{
    public class ShoppingCart
    {
        public Guid ID  { get; set; }
        public DateTime CreatedDate { get; set; }

        #region Relationships
        public ICollection<ShoppingCartDetails>? Detail { get; set; }
        #endregion
    }
}
