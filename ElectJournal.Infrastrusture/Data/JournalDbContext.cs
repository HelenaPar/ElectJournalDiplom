using ElectJournal.Infrastrusture.Data.Configurations;
using ElectJournal.Core.Entuties;
using Microsoft.EntityFrameworkCore;

namespace ElectJournal.Infrastrusture
{
    public class JournalDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Timetable> Timetable { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public JournalDbContext(DbContextOptions<JournalDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new GroupConfiguration().Configure(modelBuilder.Entity<Group>());
            new LessonConfiguration().Configure(modelBuilder.Entity<Lesson>());
            new MarkConfiguration().Configure(modelBuilder.Entity<Mark>());
            new TimetableConfiguration().Configure(modelBuilder.Entity<Timetable>());
            new SubjectConfiguration().Configure(modelBuilder.Entity<Subject>());

            modelBuilder.Entity<Role>().HasData(
                    new Role { Id = 1, Name = "admin" },
                    new Role { Id = 2, Name = "teacher" },
                    new Role { Id = 3, Name = "student" }
            );
        }
    }
}
