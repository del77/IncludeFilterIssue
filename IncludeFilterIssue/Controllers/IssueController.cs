using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncludeFilterIssue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Z.EntityFramework.Plus;

namespace IncludeFilterIssue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssueController : ControllerBase
    {


        private readonly ILogger<IssueController> _logger;
        private readonly Context _context;

        public IssueController(ILogger<IssueController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ProfessionSkill> Get()
        {
            
            var a = Issue();
            //var b = IssueWorkaround();
            //var c = IssueExtended();

            return null;
        }

        private IEnumerable<ProfessionSkill> Issue()
        {
            // this was working before I migrated from .Net core 2.2 to 3.1
            return _context.ProfessionSkills
                .IncludeFilter(ps => ps.Skilll.Names).ToList();
        }

        private IEnumerable<ProfessionSkill> IssueWorkaround()
        {
            // this solved problem
            return _context.ProfessionSkills
                .IncludeFilter(ps => ps.Skilll.Names.Where(x => true)).ToList();
        }

        private IEnumerable<Course> IssueExtended()
        {
            // a bit extended case
            // this was also ok on 2.2 but couldnt get this working on 3.1 
            return _context.Courses.IncludeFilter(c => c.SkillCourses.Select(sc => sc.Skill.Names)).ToList();
        }
    }
}