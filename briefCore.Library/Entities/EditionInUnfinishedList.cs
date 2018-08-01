namespace briefCore.Library.Entities
{
    using System;

    public class EditionInUnfinishedList
    {
        public Guid EditionId { get; set; }
        public Edition Edition { get; set; }

        public Guid UnfinishedListId { get; set; }
        public UnfinishedList UnfinishedList { get; set; }

        public string Reason { get; set; }
        public DateTime Dropped { get; set; }
    }
}