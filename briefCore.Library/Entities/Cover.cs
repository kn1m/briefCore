namespace briefCore.Library.Entities
{
    using System;
    using BaseEntities;

    public class Cover : BaseEntity
    {
        public string LinkTo { get; set; }
        public Guid EditionId { get; set; }
        public virtual Edition Edition { get; set; }
    }
}
