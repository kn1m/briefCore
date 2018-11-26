namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EditionTranslatedByMap
    {
        public EditionTranslatedByMap(EntityTypeBuilder<EditionTranslatedBy> builder)
        {
            builder.ToTable("edition_translated_by");

            builder.HasKey(et => new { et.EditionId, et.TranslatorId });

            builder.HasOne(et => et.Edition)
                .WithMany(e => e.EditionTranslatedBy)
                .HasForeignKey(et => et.EditionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(et => et.Translator)
                .WithMany(t => t.EditionTranslatedBy)
                .HasForeignKey(et => et.TranslatorId)
                .OnDelete(DeleteBehavior.Cascade);           
        }
    }
}