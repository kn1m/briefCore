namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;

    public class Whishlist
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        
        public List<EditionInWhishlist> EditionInWhishlists { get; set; }
    }
}