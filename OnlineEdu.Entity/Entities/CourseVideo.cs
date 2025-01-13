namespace OnlineEdu.Entity.Entities
{
    public class CourseVideo
    {
        public int CourseVideoID { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int VideoNumber { get; set; }
        public string? VideoUrl { get; set; }
    }
}