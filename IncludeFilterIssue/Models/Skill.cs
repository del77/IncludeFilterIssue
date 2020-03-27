using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IncludeFilterIssue.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        
        public ICollection<ProfessionSkill> ProfessionSkills { get; set; }
        public ICollection<SkillName> Names { get; set; } 

        public Skill()
        {
            ProfessionSkills = new List<ProfessionSkill>();
            Names = new List<SkillName>();
        }
    }
}