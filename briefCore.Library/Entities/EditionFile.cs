﻿namespace briefCore.Library.Entities
{
    using System;
    using brief.Library.Entities;
    using Enums;

    public class EditionFile
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public bool IsReaded { get; set; }
        public EBookFileType Type { get; set; }
        public DateTime Uploaded { get; set; }
        public Guid EditionId { get; set; }
        public virtual Edition Edition { get; set; }
    }
}
