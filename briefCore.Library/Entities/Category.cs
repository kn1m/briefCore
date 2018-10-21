namespace briefCore.Library.Entities
{
    using System;

    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
    }
}