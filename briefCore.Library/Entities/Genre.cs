namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;

    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<BookInGenre> BookInGenres { get; set; }
    }
}