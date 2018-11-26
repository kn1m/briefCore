namespace briefCore.Library.Entities
{
    using System;

    public class EditionInCategory
    {
        public Guid EditionId { get; set; }
        public Edition Edition { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}