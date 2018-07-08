namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class ExportInfoMap
    {
        public ExportInfoMap(EntityTypeBuilder<ExportInfo> builder)
        {
            builder.ToTable("export_info");
        }
    }
}