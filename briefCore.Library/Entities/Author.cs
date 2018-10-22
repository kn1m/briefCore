namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using BaseEntities;

    public class Author : BasePerson
    {
        public List<BookByAuthor> BooksByAuthor { get; set; }
    }
}
