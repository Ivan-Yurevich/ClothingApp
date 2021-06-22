using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClothingApp.Data.Common.Entities;

namespace ClothingApp.Data.Common.Configurations
{
    public abstract class BaseConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<TKey>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);

            ConfigureCustom(builder);

            builder.Property(x => x.Updated)
                .HasColumnType("datetime2(7)")
                .HasColumnName("Updated");

            builder.Property(x => x.Deleted)
                .HasColumnType("datetime2(7)")
                .HasColumnName("Deleted");
       }

        protected abstract void ConfigureCustom(EntityTypeBuilder<TEntity> builder);
    }
}
