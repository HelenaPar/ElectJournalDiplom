using ElectJournal.Core.Entuties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectJournal.Infrastrusture.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Login)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(p => p.Password)
               .HasMaxLength(264)
               .IsRequired();

            builder
               .Property(p => p.Name)
               .HasMaxLength(50)
               .IsRequired();

            builder
               .Property(p => p.LastName)
               .HasMaxLength(50)
               .IsRequired();

            builder
               .Property(p => p.MiddleName)
               .HasMaxLength(50)
               .IsRequired();

            builder
               .Property(p => p.RoleId)
               .IsRequired();

            builder
                .HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(g => g.GroupId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
