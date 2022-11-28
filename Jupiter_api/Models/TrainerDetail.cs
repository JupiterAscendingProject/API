using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jupiter_api.Models
{
    [Table("Trainer_Details")]
    public partial class TrainerDetail
    {
        [Key]
        [Column("Emp_ID")]
        public int EmpId { get; set; }
        [Column("Trainer_Name")]
        [StringLength(50)]
        [Unicode(false)]
        public string TrainerName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Column("Pass_word")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PassWord { get; set; }
        [Column("isadmin")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Isadmin { get; set; }
    }
}
