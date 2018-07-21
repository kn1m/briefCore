namespace briefCore.Library.Entities
{
    using System;

    public class NotesFile
    {
        public Guid Id { get; set; }
        public Guid ImportInfoId { get; set; }
        public ImportInfo ImportInfo { get; set; }
        public string Checksum { get; set; }
        public string Path { get; set; }
    }
}
