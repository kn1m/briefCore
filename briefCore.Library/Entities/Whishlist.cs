namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using BaseEntities;

    public class Whishlist : BaseEntity
    {
        public Guid UserId { get; set; }
        
        public List<EditionInWhishlist> EditionInWhishlists { get; set; }
    }
}