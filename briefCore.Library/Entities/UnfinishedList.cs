namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;

    public class UnfinishedList
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        
        public List<EditionInUnfinishedList> EditionInUnfinishedLists { get; set; }
    }
}