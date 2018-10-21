namespace briefCore.Library.Entities
{
    using System.Collections.Generic;
    using BaseEntities;

    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<BookInGenre> BookInGenres { get; set; }
    }
}