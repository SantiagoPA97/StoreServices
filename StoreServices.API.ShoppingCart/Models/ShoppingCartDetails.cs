namespace StoreServices.API.ShoppingCart.Models
{
    public class ShoppingCartDetails
    {
        public Guid ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid Product {  get; set; }

        #region Relationships
        public Guid ShoppingCartID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        #endregion
    }
}
