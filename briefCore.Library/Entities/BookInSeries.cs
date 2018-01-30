namespace briefCore.Library.Entities
{
    using System;
    using brief.Library.Entities;

    public class BookInSeries
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid SeriesId { get; set; }
        public Series Series { get; set; }
    }
}