namespace briefCore.Data
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EditionInCategoryMap
    {
        public EditionInCategoryMap(EntityTypeBuilder<EditionInCategory> builder)
        {
            builder.ToTable("edition_in_category");

            builder.HasKey(eu => new { eu.EditionId, eu.CategoryId });

            builder.HasOne(ec => ec.Edition)
                .WithMany(e => e.EditionInCategories)
                .HasForeignKey(ec => ec.EditionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ec => ec.Category)
                .WithMany(c => c.EditionInCategories)
                .HasForeignKey(ec => ec.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}