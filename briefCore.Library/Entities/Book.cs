namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using BaseEntities;

    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Edition> Editions { get; set; }
        public List<BookInSeries> BookInSerieses { get; set; }
        public List<BookByAuthor> BookByAuthors { get; set; }
        public List<BookInGenre> BookInGenres { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                return book.Name == Name
                    && book.Description == Description;
            }

            return false;
        }

        public override int GetHashCode()
            => 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
    }
}
