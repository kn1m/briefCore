namespace briefCore.Library.Entities
{
    using System;

    public class BookInSeries
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid SeriesId { get; set; }
        public Series Series { get; set; }
    }
}