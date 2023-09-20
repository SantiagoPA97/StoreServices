namespace StoreServices.API.Author.Models
{
    public class AcademicGrade
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? AcademicCenter { get; set; }
        public DateTime? GradeDate { get; set; }

        #region Relationships
        public Author? Author { get; set; }
        public Guid AuthorID { get; set; }
        #endregion
    }
}
