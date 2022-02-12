using ElectJournal.Core.Entuties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectJournal.Infrastrusture.Data.Configurations
{
    class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Date)
                .IsRequired();

            builder
               .Property(p => p.Homework)
               .HasMaxLength(50);

            builder
               .Property(p => p.Theme)
               .HasMaxLength(50); 

            builder
               .Property(p => p.StartTime)
               .IsRequired();

            builder
               .Property(p => p.SubjectId)
               .IsRequired();

            builder
               .Property(p => p.GroupId)
               .IsRequired();

            builder
                .HasOne(m => m.User)
                .WithMany(u => u.Lessons)
                .HasForeignKey(m => m.TeacherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
