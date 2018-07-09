namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;

    public class ImportInfo
    {
        public Guid Id { get; set; }
        public DateTime Imported { get; set; }
        public string Description { get; set; }
        public List<NotesFile> NotesFiles { get; set; }
    }
}