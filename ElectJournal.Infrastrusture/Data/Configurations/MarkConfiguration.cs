using ElectJournal.Core.Entuties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectJournal.Infrastrusture.Data.Configurations
{
    class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Value);

            builder
                .Property(p => p.StudentId)
                .IsRequired();

            builder
                .Property(p => p.LessonId)
                .IsRequired();

            builder
                .HasOne(m => m.User)
                .WithMany(u => u.Marks)
                .HasForeignKey(m => m.StudentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}