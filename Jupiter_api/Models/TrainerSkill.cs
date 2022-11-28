using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    [Keyless]
    [Table("Trainer_Skills")]
    public partial class TrainerSkill
    {
        [Column("Emp_ID")]
        public int? EmpId { get; set; }
        [Column("Skill_ID")]
        public int? SkillId { get; set; }

        [ForeignKey("EmpId")]
        public virtual TrainerDetail? Emp { get; set; }
        [ForeignKey("SkillId")]
        public virtual Skill? Skill { get; set; }
    }
}
