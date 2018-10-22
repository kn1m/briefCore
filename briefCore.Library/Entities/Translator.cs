namespace briefCore.Library.Entities
{
    using System.Collections.Generic;
    using BaseEntities;

    public class Translator : BasePerson
    {
        public List<EditionTranslatedBy> EditionTranslatedBy { get; set; }
    }
}