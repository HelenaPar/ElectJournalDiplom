namespace ElectJournal.Core.Entuties
{
    public class Mark
    {
        public int Id { get; set; }
        public byte Value { get; set; }
        public int StudentId { get; set; }
        public User User { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
