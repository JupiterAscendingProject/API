using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    public partial class Skill
    {
        [Key]
        [Column("skill_id")]
        public int SkillId { get; set; }
        [Column("skill_name")]
        [StringLength(20)]
        [Unicode(false)]
        public string? SkillName { get; set; }
    }
}
