namespace briefCore.Library.Entities
{
    using System;

    public class EditionTranslatedBy
    {
        public Guid TranslatorId { get; set; }
        public Translator Translator { get; set; }

        public Guid EditionId { get; set; }
        public Edition Edition { get; set; }
    }
}