using ElectJournal.Core.Entuties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectJournal.Infrastrusture.Data.Configurations
{
    class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
    {
        public void Configure(EntityTypeBuilder<Timetable> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                 .Property(p => p.UserId)
                 .IsRequired();

            builder
               .Property(p => p.DayOfWeek)
               .HasColumnType("tinyint")
               .IsRequired();

            builder
               .Property(p => p.BeginDate)
               .HasColumnType("date")
               .IsRequired();

            builder
               .Property(p => p.EndDate)
               .HasColumnType("date")
               .IsRequired();

            builder
               .Property(p => p.StartTime)
               .IsRequired();

            builder
               .Property(p => p.SubjectId)
               .IsRequired();
        }
    }
}
