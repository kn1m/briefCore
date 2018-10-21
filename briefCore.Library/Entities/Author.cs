namespace briefCore.Library.Entities
{
    using System.Collections.Generic;
    using BaseEntities;

    public class Author : BaseEntity
    {
        public string AuthorFirstName { get; set; }
        public string AuthorSecondName { get; set; }
        public string AuthorLastName { get; set; }
        public List<BookByAuthor> BooksByAuthor { get; set; }
    }
}
