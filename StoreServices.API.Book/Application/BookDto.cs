namespace StoreServices.API.Book.Application
{
    public class BookDto
    {
        public Guid ID { get; set; }
        public required string Title { get; set; }
        public DateTime? PublicationDate { get; set; }

        #region Navigation Properties
        public Guid AuthorID { get; set; }
        #endregion
    }
}
