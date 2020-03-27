using System.ComponentModel.DataAnnotations;

namespace IncludeFilterIssue.Models
{
    public class ProfessionSkill
    {
        [Key]
        public int Id { get; set; }
        
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        
        public int SkillId { get; set; }
        public Skill Skilll { get; set; }
    }
}