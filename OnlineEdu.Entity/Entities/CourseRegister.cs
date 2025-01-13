namespace OnlineEdu.Entity.Entities
{
    public class CourseRegister
    {
        public int CourseRegisterID { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}