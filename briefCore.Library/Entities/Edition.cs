namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using BaseEntities;
    using Enums;

    public class Edition : BaseEntity
    {
        public string Description { get; set; }
        public int? Year { get; set; }
        public int? Amount { get; set; }
        public decimal? Price { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public Guid PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public List<Cover> Covers { get; set; }
        //public virtual IList<Note> Notes { get; set; }
        public List<EditionFile> Files { get; set; }
        public List<Location> Locations { get; set; }
        public List<EditionInUnfinishedList> EditionInUnfinishedLists { get; set; }
        public List<EditionInWhishlist> EditionInWhishlists { get; set; }
        public EditionType EditionType { get; set; }
        public Language Language { get; set; }
        public Currency? Currency { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Edition edition)
            {
                return edition.PublisherId != PublisherId ||
                       edition.Description != Description ||
                       edition.BookId != BookId ||
                       edition.EditionType != EditionType ||
                       edition.Language != Language ||
                       !edition.Year.HasValue ||
                       !Year.HasValue ||
                       edition.Year.Value == Year.Value;
            }

            return false;
        }

        public override int GetHashCode()
            => 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
    }
}
