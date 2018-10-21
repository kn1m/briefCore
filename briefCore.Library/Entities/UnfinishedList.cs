namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using BaseEntities;

    public class UnfinishedList : BaseEntity
    {
        public Guid UserId { get; set; }
        
        public List<EditionInUnfinishedList> EditionInUnfinishedLists { get; set; }
    }
}