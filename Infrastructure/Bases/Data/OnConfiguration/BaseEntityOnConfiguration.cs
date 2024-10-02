//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using Domain.Bases.Entities;

//namespace Infrastructure.Bases.Data.OnConfiguration
//{
//    public class BaseEntityOnConfiguration : IEntityTypeConfiguration<BaseEntity>
//    {
//        public void Configure(EntityTypeBuilder<BaseEntity> builder)
//        {
//            builder.HasQueryFilter(x => !x.IsDeleted);
//            builder.HasIndex(x => x.IsDeleted)
//                .HasFilter("IsDeleted = 0");
//        }
//    }
//}
