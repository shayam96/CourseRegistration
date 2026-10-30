namespace CourseRegistration.Model
{
    public class WaitlistEntry
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int QueuePosition { get; set; }
    }
}
