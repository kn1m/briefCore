namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using brief.Library.Entities;

    public class Author
    {
        public Guid Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorSecondName { get; set; }
        public string AuthorLastName { get; set; }
        public List<BookByAuthor> BooksByAuthor { get; set; }
    }
}
