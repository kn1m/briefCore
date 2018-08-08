namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GenreMap
    {
        public GenreMap(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genres");

            builder.HasKey(g => g.Id);
        }
    }
}