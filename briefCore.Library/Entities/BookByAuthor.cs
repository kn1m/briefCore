namespace briefCore.Library.Entities
{
    using System;
    using brief.Library.Entities;

    public class BookByAuthor
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}