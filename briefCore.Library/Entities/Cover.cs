namespace brief.Library.Entities
{
    using System;
    using briefCore.Library.Entities;

    public class Cover
    {
        public Guid Id { get; set; }
        public string LinkTo { get; set; }
        public Guid EditionId { get; set; }
        public virtual Edition Edition { get; set; }
    }
}
