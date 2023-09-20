namespace StoreServices.API.Author.Models
{
    public class Author
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        #region Relationships
        public ICollection<AcademicGrade>? AcademicGrades { get; set; }
        #endregion
    }
}
