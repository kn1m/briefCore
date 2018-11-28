namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;
    using BaseEntities;

    public class Wishlist : BaseEntity
    {
        public Guid UserId { get; set; }
        
        public List<EditionInWishlist> EditionInWishlists { get; set; }
    }
}