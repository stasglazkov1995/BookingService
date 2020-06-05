using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookMe.BookingService.Domain.Abstractions;

namespace BookMe.BookingService.Data.Mappers.Abstractions
{
    public abstract class EntityMapper<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public EntityMapper()
        {
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
        }
    }
}
