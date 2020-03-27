using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IncludeFilterIssue.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public ICollection<SkillCourse> SkillCourses { get; set; }

        public Course()
        {
            SkillCourses = new List<SkillCourse>();
        }
    }
}