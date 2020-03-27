using IncludeFilterIssue.Models;
using Microsoft.EntityFrameworkCore;

namespace IncludeFilterIssue
{
    public class Context : DbContext  
    {  
        public Context(DbContextOptions options)  
            :base(options)  
        {  
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfessionSkill>()
                .HasOne(ps => ps.Skilll)
                .WithMany(s => s.ProfessionSkills)
                .HasForeignKey(ps => ps.SkillId);

            modelBuilder.Entity<ProfessionSkill>()
                .HasOne(ps => ps.Profession)
                .WithOne()
                .HasForeignKey<ProfessionSkill>(p => p.ProfessionId);

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Names)
                .WithOne(sn => sn.Skill)
                .HasForeignKey(sn => sn.SkillId);

            modelBuilder.Entity<SkillCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.SkillCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<SkillCourse>()
                .HasKey(sc => new {sc.CourseId, sc.SkillId});
            modelBuilder.Entity<SkillCourse>()
                .HasOne(sc => sc.Skill)
                .WithMany()
                .HasForeignKey(sc => sc.SkillId);
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<ProfessionSkill> ProfessionSkills { get; set; }
        public DbSet<SkillName> SkillNames { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SkillCourse> SkillCourses { get; set; }
    }  
}