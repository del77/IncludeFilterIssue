using System.ComponentModel.DataAnnotations;

namespace IncludeFilterIssue.Models
{
    public class SkillName
    {
        [Key]
        public int Id { get; set; }
        public string Language { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public string Name { get; set; }
    }
}