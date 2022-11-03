using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    [Keyless]
    [Table("Trainer_Module")]
    public partial class TrainerModule
    {
        [Column("Emp_ID")]
        public int EmpId { get; set; }
        [Column("Module_No")]
        public int ModuleNo { get; set; }

        [ForeignKey("EmpId")]
        public virtual TrainerDetail Emp { get; set; } = null!;
        [ForeignKey("ModuleNo")]
        public virtual ModuleDetail ModuleNoNavigation { get; set; } = null!;
    }
}
