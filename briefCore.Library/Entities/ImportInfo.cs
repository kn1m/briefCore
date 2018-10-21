namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using BaseEntities;

    public class ImportInfo : BaseEntity
    {
        public DateTime Imported { get; set; }
        public string Description { get; set; }
        public List<NotesFile> NotesFiles { get; set; }
    }
}