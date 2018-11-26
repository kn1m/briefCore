namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;

    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<EditionInCategory> EditionInCategories { get; set; }
    }
}