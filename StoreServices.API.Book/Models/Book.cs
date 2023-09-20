namespace StoreServices.API.Book.Models
{
    public class Book
    {
        public Guid ID { get; set; }
        public required string Title { get; set; }
        public DateTime? PublicationDate { get; set; }

        #region Navigation Properties
        public Guid AuthorID { get; set; }
        #endregion
    }
}
