namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class ImportInfoMap
    {
        public ImportInfoMap(EntityTypeBuilder<ImportInfo> builder)
        {
            builder.ToTable("import_info");
            
            builder.HasKey(ii => ii.Id);

            builder.Property(ii => ii.Imported);
        }
    }
}