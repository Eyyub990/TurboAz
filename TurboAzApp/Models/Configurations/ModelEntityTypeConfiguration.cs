using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TurboAzApp.Models.Configurations;
using TurboAzApp.Models.Entity;

namespace TurboAzApp.Models.Configuration
{
    public class ModelEntityTypeConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.BrandId).HasColumnType("int").IsRequired();
            builder.ConfigureAuditable();


            builder.HasKey(m => m.Id);
            builder.HasQueryFilter(m => m.DeletedAt == null);
            builder.HasOne<Brand>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Models");
        }
    }
}
