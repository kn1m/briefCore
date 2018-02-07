namespace briefCore.Library.Entities
{
    using System;

    public class ExportInfo
    {
        public Guid Id { get; set; }
        public NotesFile NotesFile { get; set; }
        public DateTime Exported { get; set; }
    }
}