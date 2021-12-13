using ElectJournal.Core.Entuties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectJournal.Infrastrusture.Data.Configurations
{
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
               .Property(p => p.Name)
               .HasMaxLength(10)
               .IsRequired();
        }
    }
}
